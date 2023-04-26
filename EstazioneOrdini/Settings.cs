using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstazioneOrdini
{
    public class Settings
    {
        public String ImagesPath = String.Empty;
        public String SaveExcelPath = String.Empty;
        public String DefaultFileName = String.Empty;


        private String _WorkPath = String.Empty;




        public Settings()
        {
            _WorkPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\EstrazioneOrdini";
            if (!System.IO.Directory.Exists(_WorkPath))
                System.IO.Directory.CreateDirectory(_WorkPath);

            this.Load();
        }
        public String WorkPath
        {
            get
            {
                return _WorkPath;

            }
        }

        public bool Load()
        {
            DataTable dt = LoadTable();

            if (dt == null)
                return false;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                this.ImagesPath = dr.Table.Columns.Contains("ImagesPath") ? dr["ImagesPath"].ToString() : String.Empty;
                this.SaveExcelPath = dr.Table.Columns.Contains("SaveExcelPath") ? dr["SaveExcelPath"].ToString() : String.Empty;
                this.DefaultFileName = dr.Table.Columns.Contains("DefaultFileName") ? dr["DefaultFileName"].ToString() : String.Empty;


                return true;
            }

            return false;
        }
        public DataTable LoadTable()
        {
            String FileXml = _WorkPath + "\\Settings.xml";
            if (System.IO.File.Exists(FileXml))
            {
                try
                {
                    DataTable dt = new DataTable();

                    dt.ReadXml(FileXml);

                    return dt;
                }
                catch { }
            }

            return null;
        }
        public void Save()
        {
            DataColumn Col;

            DataTable dtSettings = new DataTable("Settings");
            dtSettings.CaseSensitive = true;

            Col = dtSettings.Columns.Add("ImagesPath", System.Type.GetType("System.String"));
            Col.ColumnMapping = MappingType.Element;
            Col = dtSettings.Columns.Add("SaveExcelPath", System.Type.GetType("System.String"));
            Col.ColumnMapping = MappingType.Element;
            Col = dtSettings.Columns.Add("DefaultFileName", System.Type.GetType("System.String"));
            Col.ColumnMapping = MappingType.Element;

            Col.ColumnMapping = MappingType.Element;
            DataRow dr = dtSettings.NewRow();

            dr["ImagesPath"] = this.ImagesPath;
            dr["SaveExcelPath"] = this.SaveExcelPath;
            dr["DefaultFileName"] = this.DefaultFileName;


            dtSettings.Rows.Add(dr);
            SaveTable(dtSettings);
        }
        public void SaveTable(DataTable dt)
        {
            String FileXml = _WorkPath + "\\Settings.xml";

            dt.WriteXml(FileXml, XmlWriteMode.WriteSchema);
        }
    }
}
