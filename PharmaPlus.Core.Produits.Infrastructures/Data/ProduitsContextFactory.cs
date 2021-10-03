using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Infrastructures.Data
{
    class ProduitsContextFactory : IDesignTimeDbContextFactory<ProduitsContext>
    {
            #region Public methods
        public ProduitsContext CreateDbContext(string[] args)
        {
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder(); //Install Microsoft.AspNetCore.Identity.EntityFrameworkCore
            //configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appsettings.json"));
            //IConfigurationRoot configurationRoot = configurationBuilder.Build();
            //var optionsBuilder = new DbContextOptionsBuilder<ProduitsContext>();
            //optionsBuilder.UseSqlServer("ProduitsDatabase", b => b.MigrationsAssembly("PharmaPlus.Core.Produits.Migrations"));

            //return new ProduitsContext(optionsBuilder.Options);

            ConfigurationBuilder configurationbuilder = new ConfigurationBuilder();

            //configurationbuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appsettings.json"));
            configurationbuilder.AddJsonFile(Path.Combine(@"C:\Formation AEC Analyste Programmeur\Cours\Session 05\420-A21 Projet\code\PharmaPlus.API\PharmaPlus.Core.Produits.Infrastructures\Settings\appsettings.json"));

            IConfigurationRoot configurationRoot = configurationbuilder.Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configurationRoot.GetConnectionString("ProduitsDatabase"), b => b.MigrationsAssembly("PharmaPlus.Core.Produits.Migrations"));

            ProduitsContext context = new ProduitsContext(builder.Options);

            return context;
            #endregion
        }
    }
}
