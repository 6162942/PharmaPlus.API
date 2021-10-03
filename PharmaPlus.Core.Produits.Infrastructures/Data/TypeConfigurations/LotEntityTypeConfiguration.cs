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
    class LotEntityTypeConfiguration : IEntityTypeConfiguration<Lot>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.ToTable("Lot");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
