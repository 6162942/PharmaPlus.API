using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Transaction
    {
        #region Properties
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        #endregion
    }
}
