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
    class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
