using PharmaPlus.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Domain
{
    /// <summary>
    /// Repository to manage produits
    /// </summary>
    public interface IProduitsRepository : IRepository
    {
        /// <summary>
        /// Gets All produits
        /// </summary>
        /// <returns></returns>
        ICollection<Produit> GetAll(int produitId);

        /// <summary>
        /// Adds one produit in Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Produit AddOne(Produit item);

        /// <summary>
        /// Creates a new picture
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Picture AddOnePicture(string url);

        /// <summary>
        /// Update produit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Produit UpdateProduit(Produit item);
        /// <summary>
        /// Delete produit
        /// </summary>
        /// <param name="id"></param>
        //void DeleteProduit(int produitId);
        Produit DeleteProduit(int produitId);
    }
}
