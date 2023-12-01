using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstazioneOrdini2.Model
{
    internal class V_Taglia_Ordini
    {
        public string Style_Code { get; set; } // articolo
        public string Style_Description { get; set; } // descrizione
        public string Picture { get; set; } // immagine
        public string Age_Range { get; set; } // age
        public string MARCHIO { get; set; } // brand
        public string PERSONAGGIO { get; set; } // personaggio
        public string Gender { get; set; } // gender
        public string Commodity { get; set; } // tipo
        public decimal Retail_Price { get; set; } // prezzo
        public float Costo { get; set; } // costo
        public string Delivery_Date { get; set; } // data consegna
        public string Made_In { get; set; } // nazione
        public string Color_Description { get; set; } // desrizione colore
        public string Composition { get; set; } // composizione
        public float Weight_g { get; set; } // peso
        public string Size { get; set; } // taglia
        public int Quantity { get; set; } // quantita
        public string EAN_Code { get; set; } // barcode
        public string Codice_Articolo_OVS { get; set; } // articolo ovs
        public int Colore_OVS { get; set; } // colore ovs
       

        public string commodity_ovs { get; set; }
        public string macroCommodity { get; set; }
        public string fitName { get; set; }
        public string fit { get; set; }
        public string tech1 { get; set; }
        public string tech2 { get; set; }
        public string tech3 { get; set; }
        public string evidence1 { get; set; }
        public string evidence2 { get; set; }
        public string evidence3 { get; set; }
        public string Ordine { get; set; } // ordine
        public string Progressivo { get; set; } // progressivo
        public string Artwork { get; set; }



    }
}
