using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Facture
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string Etat { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<Commande> Commandes { get; set; }
        #endregion
    }
}
