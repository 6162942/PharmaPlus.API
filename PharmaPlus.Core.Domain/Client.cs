using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Client
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public string NomClient { get; set; }
        [Required]
        public string PrenomClient { get; set; }
        public string NumTelephone { get; set; }
        public int Adresse { get; set; }

        public List<Facture> Facture { get; set; }
        public List<Commande> Commandes { get; set; }
        #endregion
    }
}
