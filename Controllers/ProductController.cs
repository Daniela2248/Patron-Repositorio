using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPaternExample.Models;
using RepositoryPaternExample.Repository;

namespace RepositoryPaternExample.Controllers
{
    public class ProductController : Controller
    {
        private IProduct Iprod;

        public ProductController()
        {
            this.Iprod = new RepositoryProduct(new AlmacenEntities());
        }

        // GET: Product
        public ActionResult Index()
        {
            var ProdList = Iprod.GetProduct().ToList();
            return View(ProdList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var getprod = Iprod.GetByID(id);
            var produdisplay = new Product();
            produdisplay.Company = getprod.Company;
            produdisplay.Quantity = getprod.Quantity;
            produdisplay.ProductName = getprod.ProductName;
            produdisplay.Price = getprod.Price;
            return View(produdisplay);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Product newProd)
        {
            try
            {
                // TODO: Add insert logic here
                var addprod = new Product();
                addprod.ProductName = newProd.ProductName;
                addprod.Price = newProd.Price;
                addprod.Quantity = newProd.Quantity;
                addprod.Company = newProd.Company;
                Iprod.InsertProductRecord(addprod);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var getprod = Iprod.GetByID(id);
            var produdisplay = new Product();
            produdisplay.Company = getprod.Company;
            produdisplay.Quantity = getprod.Quantity;
            produdisplay.ProductName = getprod.ProductName;
            produdisplay.Price = getprod.Price;
            return View(produdisplay);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product produpdate, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Iprod.UpdateProductRecord(produpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var prodele = Iprod.GetByID(id);
            return View(prodele);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Iprod.DeleteProductRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
