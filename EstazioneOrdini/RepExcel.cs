using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EstazioneOrdini2.Model;
using Ganss.Excel;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.Formula.Functions;
using SixLabors.ImageSharp.Formats.Tga;

namespace EstazioneOrdini
{
    internal class RepExcel
    { 
        internal static string Export(List<V_Taglia_Ordini> lista,Settings impostazioni,string ordine)
        {
            ExcelMapper mapper = new ExcelMapper();
            //var newFile = ConfigurationManager.AppSettings["NomeFileExcel"];
            var newFile = impostazioni.SaveExcelPath + @"\" + impostazioni.DefaultFileName.Replace("NRORDINE",ordine);

            mapper.Save(newFile, lista, "Tabelle1", true);


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook sheet = excel.Workbooks.Open(newFile);
            Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

            x.Range["A1"].Value2 = "Style Code";
            x.Range["B1"].Value2 = "Style Description";
            x.Range["D1"].Value2 = "Age Range";
            x.Range["I1"].Value2 = "Retaile Price";
            x.Range["K1"].Value2 = "Delivery Date";
            x.Range["L1"].Value2 = "Made In";
            x.Range["M1"].Value2 = "Color Description";
            x.Range["O1"].Value2 = "Weight (g)";
            x.Range["R1"].Value2 = "EAN Code";
            x.Range["S1"].Value2 = "Codice Articolo OVS";
            x.Range["T1"].Value2 = "Colore OVS";

            x.Range["A1:I1"].Interior.Color = Color.Yellow;
            x.Range["J1"].Interior.Color = Color.Gray;
            x.Range["K1:R1"].Interior.Color = Color.Yellow;
            x.Range["S1:T1"].Interior.Color = Color.Gray;
            x.Range["A1:W1"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            x.Range["C1"].ColumnWidth = 40;
            //x.Range["U1:W1"].ColumnWidth = 0;

            // levo i tre campi inutili
            x.Range["U:W"].ClearContents();

            try
            {
                
                int aa = lista.Count;

                x.Range[$@"A2:A{aa + 1}"].Interior.Color = Color.LightGreen;
                //x.Rows.AutoFit();
                x.Columns["A:B"].AutoFit();
                x.Columns["D:T"].AutoFit();

                int valore_di_mezzo = 0;
                int cellStartMerge = 2;



                foreach (var item in lista.GroupBy(x => new { x.Ordine, x.Style_Code }).OrderBy(x => x.Key.Ordine))
                {

                    int itemsMerge = item.Count();
                    valore_di_mezzo = valore_di_mezzo + itemsMerge;
                    x.Range[x.Cells[cellStartMerge, 3], x.Cells[valore_di_mezzo + 1, 3]].Merge();
                    //x.Range[x.Cells[cellStartMerge, 3], x.Cells[valore_di_mezzo + 1, 3]].Value2 = valore_di_mezzo;

                    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)x.Range[x.Cells[cellStartMerge, 3], x.Cells[valore_di_mezzo + 1, 3]];

                    float Left = (float)((double)oRange.Left + 1);
                    float Top = (float)((double)oRange.Top + 1);

                    FileInfo fileArtwork = new FileInfo(impostazioni.ImagesPath + @"\" + item.FirstOrDefault().Artwork + ".jpg");
                    FileInfo file = new FileInfo(impostazioni.ImagesPath + @"\" + item.FirstOrDefault().Style_Code + ".jpg");

                    bool esisteImmagine = false;
                    if (fileArtwork.Exists)
                    {
                        esisteImmagine = true;
                        file = fileArtwork;


                    }
                    else if(file.Exists)
                    {
                        esisteImmagine = true;

                    }
                    else
                    {
                        esisteImmagine = false;

                    }
                    if (esisteImmagine == true)
                    {
                        var sizeInBytes = file.Length;

                        Bitmap img = new Bitmap(file.FullName);

                        float imageHeight = img.Height;
                        float imageWidth = img.Width;

                        float rapporto = imageWidth / imageHeight;
                        float HeightImage = 17 * (valore_di_mezzo - cellStartMerge + 1);

                        float WidthImage = rapporto * HeightImage - 2;
                        if (WidthImage > 213)
                        {
                            WidthImage = 213;
                            HeightImage = 16 * (valore_di_mezzo - cellStartMerge + 1);
                            x.Shapes.AddPicture(file.FullName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, WidthImage, HeightImage);
                        }
                        else
                        {
                            x.Shapes.AddPicture(file.FullName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, WidthImage, HeightImage);
                        }
                        cellStartMerge = valore_di_mezzo + 2;
                    }
                    else
                    {
                        cellStartMerge = valore_di_mezzo + 2;
                    }
                }

                sheet.Close(true, Type.Missing, Type.Missing);
                excel.Quit();

                    return "";
            }
            catch (Exception err)
            {
                try
                {
                    excel.Quit();
                }
                catch (Exception)
                {
 
                }

                return err.Message;
              
            }
             
        }
    }
}
