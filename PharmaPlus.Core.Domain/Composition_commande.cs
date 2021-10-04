using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Composition_commande
    {
        #region Properties
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        [Required]
        public int Quantite { get; set; }
        #endregion
    }
}
