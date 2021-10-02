using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    /// <summary>
    /// Exemple 
    /// {"Id":1,"Drug_code":225,"Class_name":"Humain","Drug_identification_number":"00000019",
    /// "Brand_name":"PLACIDYL CAP 200MG","Descriptor":"","Number_of_ais":"1",
    /// "Ai_group_no":"0107593001","Company_name":"ABBOTT LABORATORIES, LIMITED",
    /// "Last_update_date": "2008-07-23", "Purchase_price":20.00, "Sell_price":25.00
    /// "Expiry_date": "2022-07-23"}
    /// </summary>
    public class Produit
    {
        #region Properties
        public int Id { get; set; }
        public int Drug_code { get; set; }
        public string Class_name { get; set; }
        public int Drug_identification_number { get; set; }
        public string Brand_name { get; set; }
        public string Descriptor { get; set; }
        public int Number_of_ais { get; set; }
        public int Ai_group_no { get; set; }
        public string Company_name { get; set; }
        public DateTime Last_update_date { get; set; }
        public decimal Purchase_price { get; set; }
        public decimal Sell_price { get; set; }
        public decimal Ppa { get; set; }
        public DateTime Expiry_date { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        #endregion
    }
}
