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
    class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<Employe>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.ToTable("Employe");
            builder.HasKey(item => item.Id);
        }
        #endregion
    }
}
