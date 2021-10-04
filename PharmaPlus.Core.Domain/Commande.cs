using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Commande
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int FactureId { get; set; }
        public Facture Facture { get; set; }

        public List<Composition_commande> Composition_commandes { get; set; }
        public List<Transaction> Transaction { get; set; }
        #endregion
    }
}
