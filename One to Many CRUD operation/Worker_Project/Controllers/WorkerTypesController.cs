using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worker_Project.Models;

namespace Worker_Project.Controllers
{
    [Authorize]
    public class WorkerTypesController : Controller
    {
        // GET: WorkerTypes
        readonly WorkerDbContext db = new WorkerDbContext();
        public ActionResult Index()
        {
            return View(db.WorkerTypes.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(WorkerType wt)
        {
            if (ModelState.IsValid)
            {
                db.WorkerTypes.Add(wt);
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_failed");
        }
        public ActionResult Edit(int id)
        {
            
            return View(db.WorkerTypes.First(x=>x.TypeId==id));
        }
        [HttpPost]
        public ActionResult Edit(WorkerType wt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wt).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wt);
        }
        public ActionResult Delete(int id)
        {
            return View(db.WorkerTypes.First(x => x.TypeId == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var data = new WorkerType { TypeId = id };
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}