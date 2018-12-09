using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDBApplication.DataAccess;
using EmployeeDBApplication.Models;

namespace EmployeeDBApplication.Controllers
{
    public class TypeDocumentsController : Controller
    {
        private EmployeeApplicationDB db = new EmployeeApplicationDB();

        // GET: TypeDocuments
        public ActionResult Index()
        {
            return View(db.TypeDocuments.ToList());
        }

        // GET: TypeDocuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeDocument typeDocument = db.TypeDocuments.Find(id);
            if (typeDocument == null)
            {
                return HttpNotFound();
            }
            return View(typeDocument);
        }

        // GET: TypeDocuments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_TypeDocument,TypeName")] TypeDocument typeDocument)
        {
            if (ModelState.IsValid)
            {
                db.TypeDocuments.Add(typeDocument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeDocument);
        }

        // GET: TypeDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeDocument typeDocument = db.TypeDocuments.Find(id);
            if (typeDocument == null)
            {
                return HttpNotFound();
            }
            return View(typeDocument);
        }

        // POST: TypeDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_TypeDocument,TypeName")] TypeDocument typeDocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeDocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeDocument);
        }

        // GET: TypeDocuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeDocument typeDocument = db.TypeDocuments.Find(id);
            if (typeDocument == null)
            {
                return HttpNotFound();
            }
            return View(typeDocument);
        }

        // POST: TypeDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeDocument typeDocument = db.TypeDocuments.Find(id);
            db.TypeDocuments.Remove(typeDocument);
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
