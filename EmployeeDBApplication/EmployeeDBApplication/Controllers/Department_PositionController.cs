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
    public class Department_PositionController : Controller
    {
        private EmployeeApplicationDB db = new EmployeeApplicationDB();

        // GET: Department_Position
        public ActionResult Index()
        {
            var department_Position = db.Department_Position.Include(d => d.Department).Include(d => d.Position);
            return View(department_Position.ToList());
        }

        // GET: Department_Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            return View(department_Position);
        }

        // GET: Department_Position/Create
        public ActionResult Create()
        {
            ViewBag.Id_Department = new SelectList(db.Departments, "Id_Department", "Name");
            ViewBag.Id_Position = new SelectList(db.Positions, "Id_Position", "Name");
            return View();
        }

        // POST: Department_Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_D_P,Id_Department,Id_Position")] Department_Position department_Position)
        {
            if (ModelState.IsValid)
            {
                db.Department_Position.Add(department_Position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Department = new SelectList(db.Departments, "Id_Department", "Name", department_Position.Id_Department);
            ViewBag.Id_Position = new SelectList(db.Positions, "Id_Position", "Name", department_Position.Id_Position);
            return View(department_Position);
        }

        // GET: Department_Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Department = new SelectList(db.Departments, "Id_Department", "Name", department_Position.Id_Department);
            ViewBag.Id_Position = new SelectList(db.Positions, "Id_Position", "Name", department_Position.Id_Position);
            return View(department_Position);
        }

        // POST: Department_Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_D_P,Id_Department,Id_Position")] Department_Position department_Position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department_Position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Department = new SelectList(db.Departments, "Id_Department", "Name", department_Position.Id_Department);
            ViewBag.Id_Position = new SelectList(db.Positions, "Id_Position", "Name", department_Position.Id_Position);
            return View(department_Position);
        }

        // GET: Department_Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            return View(department_Position);
        }

        // POST: Department_Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_Position department_Position = db.Department_Position.Find(id);
            db.Department_Position.Remove(department_Position);
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
