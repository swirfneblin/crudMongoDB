using CrudMongoDB.Domain;
using CrudMongoDB.Models;
using System;
using System.Web.Mvc;

namespace CrudMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemDomain _itemDomain;
        
        public HomeController()
        {
            _itemDomain = new ItemDomain();
        }

        public ActionResult Index()
        {
            var itens = _itemDomain.GetAll();
            return View(itens);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (!ModelState.IsValid)
            {
                item.DataCadastro = DateTime.UtcNow;
                _itemDomain.Create(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            var item =_itemDomain.Get(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemDomain.Save(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var item = _itemDomain.Get(Id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            _itemDomain.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}