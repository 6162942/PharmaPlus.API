using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Affectation
    {
        #region Properties
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }

        public int DepartementId { get; set; }
        public Departement Departement { get; set; }
        [Required]
        public DateTime Date { get; set; }
 
        /*public int EmployeRHId { get; set; }
        public Employe EmployeRH { get; set; }*/

        #endregion
    }
}
