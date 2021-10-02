using Microsoft.Extensions.DependencyInjection;
using PharmaPlus.Core.Produits.Domain;
using PharmaPlus.Core.Produits.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaPlus.API.UI.ExtensionMethods
{
    /// <summary>
    /// Prepare customs depedency injection
    /// </summary>
    public static class DIMethods
    {
        #region Public methods
        public static void AddInjection(this IServiceCollection services)
        {
            services.AddScoped<IProduitsRepository, DefaultProduitsRepository>();
        }

        #endregion
    }
}
