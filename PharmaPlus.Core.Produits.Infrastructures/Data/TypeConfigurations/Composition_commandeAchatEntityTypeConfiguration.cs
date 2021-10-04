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
    class Composition_commandeAchatEntityTypeConfiguration : IEntityTypeConfiguration<Composition_commandeAchat>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Composition_commandeAchat> builder)
        {
            builder.ToTable("Composition_commandeAchat");
            builder.HasKey(item => new { item.CommandeAchatId, item.ProduitId });
        }
        #endregion
    }
}
