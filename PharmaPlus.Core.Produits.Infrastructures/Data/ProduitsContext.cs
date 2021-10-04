using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaPlus.Core.Framework;
using PharmaPlus.Core.Produits.Domain;
using PharmaPlus.Core.Produits.Infrastructures.Data.TypeConfigurations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Infrastructures.Data
{
    public class ProduitsContext : IdentityDbContext, IUnitOfWork
    {
        #region Contructors
            public ProduitsContext([NotNullAttribute] DbContextOptions options): base(options) { }
             public ProduitsContext() : base() { }
        #endregion

        #region Internal methodes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProduitEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PictureEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LaboratoireEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MoleculeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommandeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Composition_commandeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PosteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FactureEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfilEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AffectationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AutorisationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommandeAchatEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Composition_commandeAchatEntityTypeConfiguration());
        }
        #endregion

        #region Properties
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Molecule> Molecules { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Laboratoire> Laboratoires { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Composition_commande> Composition_commandes { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Poste> Postes { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Affectation> Affectations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Autorisation> Autorisations { get; set; }
        public DbSet<CommandeAchat> CommandeAchats { get; set; }
        public DbSet<Composition_commandeAchat> Composition_commandeAchats { get; set; }

        #endregion
    }
}
