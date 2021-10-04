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
    class PosteEntityTypeConfiguration : IEntityTypeConfiguration<Poste>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Poste> builder)
        {
            builder.ToTable("Poste");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
