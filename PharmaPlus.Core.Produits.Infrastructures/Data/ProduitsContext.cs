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
        }
        #endregion
        #region Properties
        public DbSet<Produit> Produits { get; set; }

        public DbSet<Picture> Pictures { get; set; }
        #endregion
    }
}
