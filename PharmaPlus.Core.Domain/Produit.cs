using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string NomCommercial { get; set; }
        [Required]
        public DateTime DatePeremption { get; set; }
        [Required]
        public double PrixAchat { get; set; }
        [Required]
        public string PrixVente { get; set; }
        [Required]
        public string PrixPpa { get; set; }
        public int MoleculeId { get; set; }
        public Molecule Molecule { get; set; }
        public int LotId { get; set; }
        public Lot Lot { get; set; }
        public int LaboId { get; set; }
        public Laboratoire Labo { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public List<Composition_commande> Composition_commandes { get; set; }
        #endregion
    }
}
