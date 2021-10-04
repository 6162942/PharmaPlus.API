using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPlus.Core.Produits.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Infrastructures.Data.TypeConfigurations
{
    class Composition_commandeEntityTypeConfiguration : IEntityTypeConfiguration<Composition_commande>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Composition_commande> builder)
        {
            builder.ToTable("Composition_commande");
            builder.HasKey(item => new { item.CommandeId, item.ProduitId });
        }
        #endregion
    }
}
