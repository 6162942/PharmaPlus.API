
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Profil
    {
        #region Properties
        public int Id { get; set; }
        public int PosteId { get; set; }
        public Poste Poste { get; set; }
        [Required]
        public string Description { get; set; }
        #endregion
    }
}
