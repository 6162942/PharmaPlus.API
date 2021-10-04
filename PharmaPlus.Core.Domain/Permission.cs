using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Permission
    {
        #region Properties
        public int Id { get; set; }
        public int DepartementId { get; set; }
        public string Description { get; set; }

        public List<Autorisation> Autorisations { get; set; }
        #endregion
    }
}
