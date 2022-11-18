using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScaffoldingExample2.Models;

namespace ScaffoldingExample2.Controllers
{
    public class ExampleModelsController : Controller
    {
        private ExampleModelContext db = new ExampleModelContext();

        // GET: ExampleModels
        public ActionResult Index()
        {
            return View(db.exampleModels.ToList());
        }

        // GET: ExampleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModel exampleModel = db.exampleModels.Find(id);
            if (exampleModel == null)
            {
                return HttpNotFound();
            }
            return View(exampleModel);
        }

        // GET: ExampleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExampleModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,JoiningDate,Age")] ExampleModel exampleModel)
        {
            if (ModelState.IsValid)
            {
                db.exampleModels.Add(exampleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exampleModel);
        }

        // GET: ExampleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModel exampleModel = db.exampleModels.Find(id);
            if (exampleModel == null)
            {
                return HttpNotFound();
            }
            return View(exampleModel);
        }

        // POST: ExampleModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,JoiningDate,Age")] ExampleModel exampleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exampleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exampleModel);
        }

        // GET: ExampleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModel exampleModel = db.exampleModels.Find(id);
            if (exampleModel == null)
            {
                return HttpNotFound();
            }
            return View(exampleModel);
        }

        // POST: ExampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExampleModel exampleModel = db.exampleModels.Find(id);
            db.exampleModels.Remove(exampleModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
