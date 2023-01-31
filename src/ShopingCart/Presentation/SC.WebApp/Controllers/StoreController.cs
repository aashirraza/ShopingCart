using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.Business.Interfaces;
using SC.Business.Model;

namespace SC.WebApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreServices _storeService;

        public StoreController(IStoreServices storeService)
        {
            _storeService = storeService;
        }


        // GET: StoreController
        public ActionResult Index()
        {
            var storeModel = new StoreModel { Name = "Store 1", Description = "Des 1", Location = "Loc 1" };
            _storeService.Add(storeModel);

            var models= _storeService.GetAll();
            return View(models);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
