using tdi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tdi.Controllers
{
    public class ItemController : Controller
    {
        private CoopEntities _db = new CoopEntities();
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
            if (!ModelState.IsValid)
                return View();

            _db.Items.Add(ItemToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}