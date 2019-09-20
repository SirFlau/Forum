using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutenticationTest.App_data;
using AutenticationTest.Models;

namespace AutenticationTest.Controllers
{
    public class TopicController : Controller
    {
        private AuthenticateDB db = new AuthenticateDB();

        // GET: TopicModels
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        // GET: TopicModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicModel topicModel = db.Topics.Find(id);
            if (topicModel == null)
            {
                return HttpNotFound();
            }
            return View(topicModel);
        }

        // GET: TopicModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopicModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] TopicModel topicModel)
        {
            if (ModelState.IsValid)
            {
                topicModel.Id = Guid.NewGuid();
                db.Topics.Add(topicModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topicModel);
        }

        // GET: TopicModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicModel topicModel = db.Topics.Find(id);
            if (topicModel == null)
            {
                return HttpNotFound();
            }
            return View(topicModel);
        }

        // POST: TopicModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TopicModel topicModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topicModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topicModel);
        }

        // GET: TopicModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopicModel topicModel = db.Topics.Find(id);
            if (topicModel == null)
            {
                return HttpNotFound();
            }
            return View(topicModel);
        }

        // POST: TopicModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TopicModel topicModel = db.Topics.Find(id);
            db.Topics.Remove(topicModel);
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
