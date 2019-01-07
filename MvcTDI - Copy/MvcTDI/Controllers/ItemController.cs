using MvcTDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTDI.Controllers
{
    public class ItemController : Controller
    {
        private Entities1 _db = new Entities1();
        // GET: Item
        public ActionResult Index()
        {
            return View(_db.Items.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            var itemToDetails = (from m in _db.Items where m.inventory_id == id select m).First();
            return View(itemToDetails);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "inventory_id")] Item ItemToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.Items.Add(ItemToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
