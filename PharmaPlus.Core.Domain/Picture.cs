using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Picture
    {
        #region Properties
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Produit> Produits { get; set; }

        public List<Composition_commandeAchat> Composition_commandeAchats { get; set; }
        #endregion
    }
}
