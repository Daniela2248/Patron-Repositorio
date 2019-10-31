using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPaternExample.Models;

namespace RepositoryPaternExample.Repository
{
    interface IProduct
    {
        void InsertProductRecord(Product prod);
        IEnumerable<Product> GetProduct();
        void UpdateProductRecord(Product prod);
        void DeleteProductRecord(int ProdID);
        Product GetByID(int ProdID);
    }
}
