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
    class CommandeAchatEntityTypeConfiguration : IEntityTypeConfiguration<CommandeAchat>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<CommandeAchat> builder)
        {
            builder.ToTable("Commande_Achat");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
