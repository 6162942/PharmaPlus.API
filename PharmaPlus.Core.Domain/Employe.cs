using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    public class Employe
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public string NomEmploye { get; set; }
        [Required]
        public string PrenomEmploye { get; set; }
        public string NumTelePers { get; set; }
        public int NumTeleProf { get; set; }
        public int Adresse { get; set; }
        public int IdPoste { get; set; }
        public Poste Poste { get; set; }

        public List<Affectation> Affectations { get; set; }
        //public List<Affectation> AffectationsRH { get; set; }
        public List<Autorisation> Autorisations { get; set; }
        public List<CommandeAchat> CommandeAchats { get; set; }
        public List<Transaction> Transaction { get; set; }
        #endregion
    }
}
