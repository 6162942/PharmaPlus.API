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
    class MoleculeEntityTypeConfiguration : IEntityTypeConfiguration<Molecule>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Molecule> builder)
        {
            builder.ToTable("Molecule");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
