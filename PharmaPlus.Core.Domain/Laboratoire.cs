using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Laboratoire
    {
        #region Properties
        public int Id { get; set; }
        public string NomLabo { get; set; }
        public string AdresseLabo { get; set; }

        public List<Produit> Produit { get; set; }

        #endregion
    }
}
