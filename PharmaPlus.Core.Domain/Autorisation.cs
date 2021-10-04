using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Autorisation
    {
        #region Properties
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public int DepartementId { get; set; }
        public Departement Departement { get; set; }     
        public int EmployeRHId { get; set; }
        public Employe EmployeRH { get; set; }
        #endregion
    }
}
