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
    class CommandeEntityTypeConfiguration : IEntityTypeConfiguration<Commande>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Commande> builder)
        {
            builder.ToTable("Commande");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
