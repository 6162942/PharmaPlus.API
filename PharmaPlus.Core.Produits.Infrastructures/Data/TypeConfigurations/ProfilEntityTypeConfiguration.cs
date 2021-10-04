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
    class ProfilEntityTypeConfiguration : IEntityTypeConfiguration<Profil>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Profil> builder)
        {
            builder.ToTable("Profil");
            builder.HasKey(item => new { item.Id, item.PosteId });
        }
        #endregion
    }
}
