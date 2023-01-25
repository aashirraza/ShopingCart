using Microsoft.AspNetCore.Mvc;
using SC.Business.Interfaces;
using SC.Business.Model;

namespace SC.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        // GET: ProductController
        public ActionResult Index(string search)
        {
            List<ProductModel> products;
            if (search == null)
            {
                products =  _productServices.GetAll();
            }
            else
            {
                products = _productServices.Search(search);
            }
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
             
        {
            try
            {
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
