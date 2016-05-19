using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListDB.Models;

namespace ToDoListDB.Controllers
{
    public class Table_TaskController : Controller
    {
        private ToDoListEntities db = new ToDoListEntities();

        // GET: Table_Task
        public ActionResult Index()
        {
            return View(db.Table_Task.ToList());
            //this returns all the tasks from the db list
        }

        // GET: Table_Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Task table_Task = db.Table_Task.Find(id);
            if (table_Task == null)
            {
                return HttpNotFound();
            }
            return View(table_Task);
        }

        // GET: Table_Task/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Tasks/MarkDone/5
        //we are makinga public method
        [HttpPost]
        public ActionResult MarkDone(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Task table_Task = db.Table_Task.Find(id);
            if (table_Task == null)
            {
                return HttpNotFound();
            }
            table_Task.TaskDone = true;
            db.Entry(table_Task).State = EntityState.Modified;
            db.SaveChanges();
  
            return RedirectToAction("Index"); //but this doesn't really change the item to marked

        }
        //this POST needs to be wired to something to work - we need to make the checkbox a FORM so we can POST

        // POST: Table_Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskDueDate,TaskName,TaskDone")] Table_Task table_Task)
        {
            if (ModelState.IsValid)
            {
                db.Table_Task.Add(table_Task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Task);
        }

        // GET: Table_Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Task table_Task = db.Table_Task.Find(id);
            if (table_Task == null)
            {
                return HttpNotFound();
            }
            return View(table_Task);
        }

        // POST: Table_Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskDueDate,TaskName,TaskDone")] Table_Task table_Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Task);
        }

        // GET: Table_Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Task table_Task = db.Table_Task.Find(id);
            if (table_Task == null)
            {
                return HttpNotFound();
            }
            return View(table_Task);
        }

        // POST: Table_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Task table_Task = db.Table_Task.Find(id);
            db.Table_Task.Remove(table_Task);
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
