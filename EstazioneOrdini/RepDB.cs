using EstazioneOrdini2.Model;
using Oracle.ManagedDataAccess.Client;
using Client;

namespace EstazioneOrdini
{
    internal class RepDB
    {

        internal static List<V_Taglia_Ordini> GetOrdini(string NumeroOrdine)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["Protex"].ConnectionString;
            string sql = $@"SELECT articolo,artwork,descrizione,ordine,progressivo,age,brand,personaggio,gender,tipo,prezzo,costo,dataconsegna,nazione,descrizionecolore,composizione,peso,taglia,quantita,barcode,articoloovs,coloreovs FROM V_Taglia_Ordini WHERE ORDINE = '{NumeroOrdine}' order by ordine,articolo";

            OracleCommand command = new OracleCommand(sql);
            command.Connection = new OracleConnection(connString);
            command.Connection.Open();
            command.CommandText = sql;

            List<V_Taglia_Ordini> lista = new List<V_Taglia_Ordini>();

            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    V_Taglia_Ordini vto = new V_Taglia_Ordini();
                    vto.Style_Code = reader["ARTICOLO"].ToString();
                    vto.Style_Description = reader["DESCRIZIONE"].ToString();
                    //vto.Picture = "";
                    vto.Age_Range = reader["AGE"].ToString();
                    vto.MARCHIO = reader["BRAND"].ToString();
                    vto.PERSONAGGIO = reader["PERSONAGGIO"].ToString();
                    vto.Gender = reader["GENDER"].ToString();
                    vto.Commodity = reader["TIPO"].ToString();
                    vto.Retail_Price = decimal.Round(Func.StringToDecimal(reader["PREZZO"].ToString()), 2);
                    vto.Costo = 0;
                    vto.Delivery_Date = Utility.Utility.ProtexToDateTime(reader["DATACONSEGNA"].ToString()).ToString("dd/MM/yyyy");
                    vto.Made_In = reader["NAZIONE"].ToString();
                    vto.Color_Description = reader["DESCRIZIONECOLORE"].ToString();
                    vto.Composition = reader["COMPOSIZIONE"].ToString();
                    vto.Weight_g = float.Parse(reader["PESO"].ToString());
                    vto.Size = reader["TAGLIA"].ToString();
                    vto.Quantity = Func.StringToInt(reader["QUANTITA"].ToString());
                    vto.EAN_Code = Func.StringToInt(reader["BARCODE"].ToString());
                    vto.Codice_Articolo_OVS = reader["ARTICOLOOVS"].ToString();
                    vto.Colore_OVS = Func.StringToInt(reader["COLOREOVS"].ToString());
                    vto.Ordine = reader["ORDINE"].ToString();
                    vto.Progressivo = reader["PROGRESSIVO"].ToString();
                    vto.Artwork = reader["ARTWORK"].ToString();

                    lista.Add(vto);

                }
                command.Connection.Close();
                command.Connection.Dispose();

                return lista;
            }
        }
    }
}
