using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPaternExample.Models;

namespace RepositoryPaternExample.Repository
{
    public class RepositoryProduct : IProduct
    {

        private AlmacenEntities almacenEntities;

        public RepositoryProduct(AlmacenEntities almacenEntities)
        {
            this.almacenEntities = almacenEntities;
        }

        public void DeleteProductRecord(int ProdID)
        {
            Product deleprod = almacenEntities.Product.Find(ProdID);
            almacenEntities.Product.Remove(deleprod);
            almacenEntities.SaveChanges();
        }

        public Product GetByID(int ProdID)
        {
            return almacenEntities.Product.Find(ProdID);
        }

        public IEnumerable<Product> GetProduct()
        {
            return almacenEntities.Product.ToList();
        }

        public void InsertProductRecord(Product prod)
        {
            almacenEntities.Product.Add(prod);
            almacenEntities.SaveChanges();
        }

        public void UpdateProductRecord(Product prod)
        {
            almacenEntities.Entry(prod).State = System.Data.Entity.EntityState.Modified;
            almacenEntities.SaveChanges();
        }
    }
}