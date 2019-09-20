using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutenticationTest.App_data;
using AutenticationTest.Models;
using AutenticationTest.Models.Forum.Models;
using Microsoft.AspNet.Identity;

namespace AutenticationTest.Controllers
{
    public class BlogPostModelsController : Controller
    {
        private AuthenticateDB db = new AuthenticateDB();

        // GET: BlogPostModels
        public ActionResult Index()
        {
            List<BlogPostModel> blogPostModels = db.Posts.Include(x => x.User).Include(x => x.Topic).ToList();

            List<UserModel> userModels = blogPostModels.Select(x => x.User).Distinct().ToList();

            foreach (UserModel user in userModels)
            {
                string imageBase64Data = Convert.ToBase64String(user.Image);
                string imageDataURL = string.Format($"data:{user.ImageType};base64,{imageBase64Data}");

                //MemoryStream ms = new MemoryStream(user.Image);
                //Image image = Image.FromStream(ms, true);
                ViewData[user.Id.ToString()] = imageDataURL;
            }

            return View(db.Posts.Include(x=> x.User).Include(x=> x.Topic).ToList());
        }

        // GET: BlogPostModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostModel blogPostModel = db.Posts.Find(id);
            if (blogPostModel == null)
            {
                return HttpNotFound();
            }
            return View(blogPostModel);
        }

        // GET: BlogPostModels/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Topic_Id = new SelectList(db.Topics, "Id", "Name");
            return View();
        }

        // POST: BlogPostModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Subject,Content,Topic_Id")] BlogPostModel blogPostModel)
        {
            string guid = Guid.Parse(User.Identity.GetUserId()).ToString();
            UserModel user = db.UserModels.FirstOrDefault(x => x.ApplicationUser_Id == guid);

            if (ModelState.IsValid)
            {
                blogPostModel.Id = Guid.NewGuid();
                blogPostModel.User = user;
                blogPostModel.CreatedDate = DateTime.Now;
                db.Posts.Add(blogPostModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPostModel);
        }

        // GET: BlogPostModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostModel blogPostModel = db.Posts.Find(id);
            if (blogPostModel == null)
            {
                return HttpNotFound();
            }
            return View(blogPostModel);
        }

        // POST: BlogPostModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,CreatedDate,Content,Topic_Id,User_Id")] BlogPostModel blogPostModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPostModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPostModel);
        }

        // GET: BlogPostModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPostModel blogPostModel = db.Posts.Find(id);
            if (blogPostModel == null)
            {
                return HttpNotFound();
            }
            return View(blogPostModel);
        }

        // POST: BlogPostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BlogPostModel blogPostModel = db.Posts.Find(id);
            db.Posts.Remove(blogPostModel);
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
