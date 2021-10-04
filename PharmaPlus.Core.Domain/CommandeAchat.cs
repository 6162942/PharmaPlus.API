using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class CommandeAchat
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int EmployeRHId { get; set; }
        public Employe EmployeRH { get; set; }

        public List<Composition_commande> Composition_commandes { get; set; }
        #endregion
    }
}
