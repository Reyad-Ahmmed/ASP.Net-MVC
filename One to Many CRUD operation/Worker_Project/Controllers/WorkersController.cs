using Worker_Project.Models;
using Worker_Project.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Worker_Project.Controllers
{
    [Authorize]
    public class WorkersController : Controller
    {
        // GET: Workers
        readonly WorkerDbContext db = new WorkerDbContext();
        public ActionResult Index()
        {
            return View(db.Workers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.TypeList = db.WorkerTypes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(WorkerViewModel w)
        {
            if (ModelState.IsValid)
            {

                var f = Server.MapPath("~/UploadImages/");
                string file = Guid.NewGuid() + Path.GetExtension(w.Picture.FileName);
                w.Picture.SaveAs( f+ file);
                var pic = new Worker {WorkerName = w.WorkerName, Salary = w.Salary, Picture = file, TypeId = w.TypeId };
                db.Workers.Add(pic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeList = db.WorkerTypes.ToList();
            return View(w);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Workers.First(x => x.WorkerId == id);
            ViewBag.TypeList = db.WorkerTypes.ToList();
            return View(new WorkerViewModel 
                        {WorkerId=data.WorkerId,
                        WorkerName=data.WorkerName,
                        Salary=data.Salary,
                        TypeId=data.TypeId });
        }
        [HttpPost]
        public ActionResult Edit(WorkerViewModel w)
        {
            if (ModelState.IsValid)
            {
                var wo = db.Workers.First(x => x.WorkerId == w.WorkerId);
                if(w.Picture!= null && w.Picture.FileName != "")
                {
                    var f = Server.MapPath("~/UploadImages/");
                    string file = Guid.NewGuid() + Path.GetExtension(w.Picture.FileName);
                    w.Picture.SaveAs(f + file);
                    wo.Picture = file;
                }
                wo.WorkerName = w.WorkerName;
                wo.Salary = w.Salary;
                wo.TypeId = w.TypeId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeList = db.WorkerTypes.ToList();
            return View(w);
        }
        public ActionResult Delete(int id)
        {
            
            return View(db.Workers.First(x => x.WorkerId == id));
        }
        [HttpPost]
        public ActionResult Delete(Worker w)
        {
            db.Entry(w).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}