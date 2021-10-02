using PharmaPlus.Core.Framework;
using PharmaPlus.Core.Produits.Domain;
using PharmaPlus.Core.Produits.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Produits.Infrastructures.Repositories
{
    public class DefaultProduitsRepository : IProduitsRepository
    {
        #region Fields
        private readonly ProduitsContext _context = null;
        #endregion

        #region Constructor
        public DefaultProduitsRepository(ProduitsContext context)
        {
            this._context = context;
        }

        #endregion

        #region Public methodes
        public ICollection<Produit> GetAll(int produitId)
        {
            var query = this._context.Produits.ToList().AsQueryable();
            if(produitId > 0)
            {
                query = query.Where(item => item.Id == produitId);
            }
            return query.ToList();
        }

        public Produit AddOne(Produit item)
        {
            return this._context.Produits.Add(item).Entity;
        }

        public Picture AddOnePicture(string url)
        {
            return this._context.Pictures.Add(new Picture() 
            { 
                Url = url
            }).Entity;
        }

        public Produit UpdateProduit(Produit item)
        {
            throw new NotImplementedException();
        }

        public Produit DeleteProduit(int produitId)
        {
            var produit = GetAll(produitId).ToList();
            
            
            Produit DeletedProduit = this._context.Produits.Remove(produit.First(x => x.Id == produitId)).Entity;

            return DeletedProduit;
        }
        #endregion

        #region Properties
        public IUnitOfWork unitOfWork => this._context;
        #endregion
    }
}
