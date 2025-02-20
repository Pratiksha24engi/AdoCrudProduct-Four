using AdoCrudProduct_Four.Models;
using AdoCrudProduct_Four.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoCrudProduct_Four.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        ProductServices db;
        public ProductController()
        {
            db = new ProductServices();
        }
        public ActionResult Index()
        {
           List<product> lst = db.GetAllProduct();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(product tp)
        {
            db.AddProducts(tp);
            ModelState.Clear();
            ViewBag.msg = db.GetAllProduct();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            product p = db.GetProductById(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(product tp)
        {
            db.UpdateProduct(tp);
            ModelState.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}