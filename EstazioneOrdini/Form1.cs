using System.IO;
using Microsoft.VisualBasic;
//using OfficeOpenXml;
using EstazioneOrdini2.Model;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Ganss.Excel;
using Org.BouncyCastle.Bcpg.OpenPgp;
using NPOI.SS.UserModel;
using System;
using NPOI.SS.Util;
using Microsoft.Office.Interop.Excel;
using NPOI.XWPF.UserModel;
using NPOI.SS.Formula.Functions;

namespace EstazioneOrdini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            lblFatto.Visible = false;
            lblErrore.Visible = false;

            if (txtNumOrdine.Text == "")
            {
                return;
            }

            if (File.Exists(@"C:\Prova\Ciccio.xlsx"))
            {
                File.Delete(@"C:\Prova\Ciccio.xlsx");
            }

            string connString = @"DATA SOURCE=10.99.99.15:1521/PROTEX;PASSWORD=PROTEX;PERSIST SECURITY INFO=True;USER ID=PROTEX";
            string sql = "SELECT articolo,descrizione,ordine,progressivo,age,brand,personaggio,gender,tipo,prezzo,costo,dataconsegna,nazione,descrizionecolore,composizione,peso,taglia,quantita,barcode,articoloovs,coloreovs FROM V_Taglia_Ordini WHERE ORDINE = '" + txtNumOrdine.Text + "' order by ordine,progressivo,articolo";

            //OracleConnection cn = new OracleConnection();
            //cn.ConnectionString = connString;
            //cn.Open();

            OracleCommand command = new OracleCommand(sql);
            command.Connection = new OracleConnection(connString);
            command.Connection.Open();
            command.CommandText = sql;

            List<V_Taglia_Ordini> lista = new List<V_Taglia_Ordini>();
            //DataTable dt = new DataTable();
            //lista.Add(new V_Taglia_Ordini() { ditta = "", ordine = "" });

            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    V_Taglia_Ordini vto = new V_Taglia_Ordini();
                    vto.Style_Code = reader["ARTICOLO"].ToString();
                    vto.Style_Description = reader["DESCRIZIONE"].ToString();
                    //vto.Picture = "";
                    vto.Ordine = reader["ORDINE"].ToString();
                    vto.Progressivo = reader["PROGRESSIVO"].ToString();
                    vto.Age_Range = reader["AGE"].ToString();
                    vto.MARCHIO = reader["BRAND"].ToString();
                    vto.PERSONAGGIO = reader["PERSONAGGIO"].ToString();
                    vto.Gender = reader["GENDER"].ToString();
                    vto.Commodity = reader["TIPO"].ToString();
                    vto.Retail_Price = Func.StringToFloat(reader["PREZZO"].ToString());
                    vto.Costo = Func.StringToFloat(reader["COSTO"].ToString());
                    vto.Delivery_Date = reader["DATACONSEGNA"].ToString();
                    vto.Made_In = reader["NAZIONE"].ToString();
                    vto.Color_Description = reader["DESCRIZIONECOLORE"].ToString();
                    vto.Composition = reader["COMPOSIZIONE"].ToString();
                    vto.Weight_g = Func.StringToFloat(reader["PESO"].ToString());
                    vto.Size = reader["TAGLIA"].ToString();
                    vto.Quantity = Func.StringToInt(reader["QUANTITA"].ToString());
                    vto.EAN_Code = Func.StringToInt(reader["BARCODE"].ToString());
                    vto.Codice_Articolo_OVS = reader["ARTICOLOOVS"].ToString();
                    vto.Colore_OVS = Func.StringToInt(reader["COLOREOVS"].ToString());
                    lista.Add(vto);

                }
                //dt.Rows.Add(lista);
            }

            if (lista.Count == 0)
            {
                lblErrore.Visible = true;
                txtNumOrdine.Text = "";
                return;
            }

            //cn.Close();

            ExcelMapper mapper = new ExcelMapper();
            var newFile = @"C:\Prova\Ciccio.xlsx";
            mapper.Save(newFile, lista, "Tabelle1", true);


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(@"C:\Prova\Ciccio.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;


            x.Range["A1:K1"].Interior.Color = Color.Yellow;
            x.Range["L1"].Interior.Color = Color.Gray;
            x.Range["M1:T1"].Interior.Color = Color.Yellow;
            x.Range["U1:V1"].Interior.Color = Color.Gray;
            x.Range["A1:V1"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            int aa = lista.Count;

            x.Range[$@"A2:A{aa + 1}"].Interior.Color = Color.LightGreen;

            // immagine
            //x.Shapes.AddPicture(@"C:\Prova\Immagine\leo.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 75, 75, 350, 50);

            x.Columns.AutoFit();

            // unisce celle


            // in questo caso :
            // progressivo | articolo | ordine
            // 0001        | TAGLIA   | 086197
            // 0002        | GIACCA   | 086197

            //System.Data.DataTable results = new System.Data.DataTable();
            //using (OracleConnection thisConnection = new OracleConnection(connString))
            //{
            //    OracleCommand cmd = new OracleCommand("select distinct progressivo, articolo, ordine from V_Taglia_Ordini WHERE ordine = '" + txtNumOrdine.Text + "' order by ordine,progressivo,articolo", thisConnection);
            //    thisConnection.Open();
            //    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            //    adapter.Fill(results);


            //    // per ogni riga della tabella sopra conto quante righe ci sono
            //    // metto il valore dentro a una altra tabella
            //    // prendo quel valore e lo uso per unire le celle

            //    int valore_di_mezzo = 0;
            //    System.Data.DataTable results2 = new System.Data.DataTable();
            //    foreach (DataRow row in results.Rows)
            //    {
            //        results2.Clear();
            //        OracleCommand cmd2 = new OracleCommand("select count(*) as conto from V_Taglia_Ordini where ordine = '" + row["ordine"].ToString() + "' and articolo = '" + row["articolo"].ToString() + "' and progressivo = '" + row["progressivo"].ToString() + "'");
            //        OracleDataAdapter adapter2 = new OracleDataAdapter(cmd2);
            //        adapter2.Fill(results2);
            //        DataRow dr = results2.Rows[0];
            //        if (valore_di_mezzo == 0)
            //        {
            //            x.Range[x.Cells[2, 3], x.Cells[dr["conto"], 3]].Merge();
            //            valore_di_mezzo = int.Parse(dr["conto"].ToString());
            //        }
            //        else
            //        {
            //            x.Range[x.Cells[valore_di_mezzo + 1, 3], x.Cells[dr["conto"], 3]].Merge();
            //        }
            //    }

            //}

            x.Range[x.Cells[2, 3], x.Cells[11, 3]].Merge();
            x.Range[x.Cells[12, 3], x.Cells[31, 3]].Merge();

            sheet.Close(true, Type.Missing, Type.Missing);
            excel.Quit();

            lblFatto.Visible = true;
        }
    }
}