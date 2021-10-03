using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Lot
    {
        public int Id { get; set; }
        [Required]
        public DateTime date { get; set; }
        public string remarque { get; set; }
    }
}
