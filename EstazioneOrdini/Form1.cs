using EstazioneOrdini2.Model;
using MathNet.Numerics.Optimization;
using Microsoft.VisualBasic;
using NPOI.SS.Formula.Functions;

namespace EstazioneOrdini
{
    public partial class Form1 : Form
    {
        Settings impostazioni = new Settings();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtImmagini.Text = impostazioni.ImagesPath;
            txtCartellaExcel.Text = impostazioni.SaveExcelPath;

            if (impostazioni.DefaultFileName != null && impostazioni.DefaultFileName != String.Empty)
            {
                txtNomeFileExcel.Text = impostazioni.DefaultFileName;
            }
            else
            {
                txtNomeFileExcel.Text = "Ordine_NRORDINE.xlsx";
                impostazioni.DefaultFileName = txtNomeFileExcel.Text;
                impostazioni.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = @"C:\";
            folderBrowserDialog.ShowDialog();
            txtCartellaExcel.Text = folderBrowserDialog.SelectedPath;
            impostazioni.SaveExcelPath = txtCartellaExcel.Text;
            impostazioni.Save();
        }

        private void btnImmagini_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = @"C:\";
            folderBrowserDialog.ShowDialog();
            txtImmagini.Text = folderBrowserDialog.SelectedPath;
            impostazioni.ImagesPath = txtImmagini.Text;
            impostazioni.Save();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            string numeroOrdine = txtNumOrdine.Text;
            numeroOrdine = numeroOrdine.PadLeft(6, '0');

            lblFatto.Visible = false;
            lblErrore.Visible = false;
            lblCarica.Visible = true;

            if (numeroOrdine == "")
            {
                return;
            }

            //if (File.Exists(@"C:\Prova\Ciccio.xlsx"))
            //{
            //    File.Delete(@"C:\Prova\Ciccio.xlsx");
            //}

            List<V_Taglia_Ordini> lista = RepDB.GetOrdini(numeroOrdine);

            if (lista.Count == 0)
            {
                lblErrore.Visible = true;
                lblCarica.Visible = false;
                //txtNumOrdine.Text = "";
                return;
            }

            if (impostazioni.Load())
            {
                RepExcel.Export(lista, impostazioni, txtNumOrdine.Text);

            }
            else
            {
                MessageBox.Show("CARICARE CARTELLA");
                Close();
            }

            lblFatto.Visible = true;
            lblCarica.Visible = false;
        }

        private void txtNumOrdine_TextChanged(object sender, EventArgs e)
        {
            lblFatto.Visible = false;
            lblErrore.Visible = false;
            //lblCarica.Visible = false;
        }
    }
}