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
    class AutorisationEntityTypeConfiguration : IEntityTypeConfiguration<Autorisation>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Autorisation> builder)
        {
            builder.ToTable("Autorisation");
            builder.HasKey(item => new { item.DepartementId, item.PermissionId });
        }
        #endregion
    }
}
