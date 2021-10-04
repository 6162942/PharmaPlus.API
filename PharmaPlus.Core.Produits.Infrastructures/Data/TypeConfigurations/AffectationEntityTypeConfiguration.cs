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
    class AffectationEntityTypeConfiguration : IEntityTypeConfiguration<Affectation>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Affectation> builder)
        {
            builder.ToTable("Affectation");
            builder.HasKey(item => new { item.EmployeId, item.DepartementId });
        }
        #endregion
    }
}
