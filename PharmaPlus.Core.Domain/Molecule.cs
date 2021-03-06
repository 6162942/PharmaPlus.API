using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Molecule
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public string NomMolecule { get; set; }

        public List<Produit> Produit { get; set; }
        #endregion
    }
}
