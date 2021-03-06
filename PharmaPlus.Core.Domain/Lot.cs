using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Lot
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Remarque { get; set; }

        public List<Produit> Produit { get; set; }
        #endregion
    }
}
