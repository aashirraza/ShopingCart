using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC.Business.Interfaces;
using SC.Business.Model;

namespace SC.WebApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        // GET: ProductController
        public ActionResult Index(int StoreId, string? search = "")
        {
            ViewBag.StoreId= StoreId;
            ViewBag.searchTerm = search;

            var products = _productServices.ProductsForStore(StoreId, search);
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create(int? StoreId)
        {
            ViewBag.StoreId = StoreId;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
             
        {
            try
            {
                model.Store = null;
                _productServices.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productServices.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                _productServices.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _productServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
