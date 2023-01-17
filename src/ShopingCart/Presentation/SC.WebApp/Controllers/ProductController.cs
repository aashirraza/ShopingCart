using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.Business.DataServices;
using SC.Business.DataServices.Interfaces;
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
            List<ProductModel> products = null; 
            if (search == null)
            {
                products =  _productServices.GetAll();
            }
            else
            {
                products = _productServices.GetAll().Where(x => x.Name.ToLower()
                .Contains(search.Trim().ToLower())).ToList();
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
                var product = _productServices.GetAll().Where(x => x.Id == model.Id ).FirstOrDefault();
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Catagory = model.Catagory;
                    product.Company = model.Company;
                }
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
