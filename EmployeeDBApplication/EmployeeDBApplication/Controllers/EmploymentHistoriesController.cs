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
    public class EmploymentHistoriesController : Controller
    {
        private EmployeeApplicationDB db = new EmployeeApplicationDB();

        // GET: EmploymentHistories
        public ActionResult Index()
        {
            var employmentHistories = db.EmploymentHistories.Include(e => e.Employee);
            return View(employmentHistories.ToList());
        }

        // GET: EmploymentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistories.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Create
        public ActionResult Create()
        {
            ViewBag.Id_Employee = new SelectList(db.Employees, "Id_Employee", "FullName");
            return View();
        }

        // POST: EmploymentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_EmploymentHistory,EmploymentDate,DateOfDismissal,Id_Employee,Experience")] EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.EmploymentHistories.Add(employmentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Employee = new SelectList(db.Employees, "Id_Employee", "FullName", employmentHistory.Id_Employee);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistories.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Employee = new SelectList(db.Employees, "Id_Employee", "FullName", employmentHistory.Id_Employee);
            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_EmploymentHistory,EmploymentDate,DateOfDismissal,Id_Employee,Experience")] EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employmentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Employee = new SelectList(db.Employees, "Id_Employee", "FullName", employmentHistory.Id_Employee);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistories.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmploymentHistory employmentHistory = db.EmploymentHistories.Find(id);
            db.EmploymentHistories.Remove(employmentHistory);
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
