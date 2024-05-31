using cellphonesweb.Models;
using cellphonesweb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace cellphonesweb.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Post
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = db.Post.OrderByDescending(x => x.Id).ToPagedList(pageIndex, pageSize);
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.CategoryId = 3;
                model.Alias = cellphonesweb.Models.Commons.Filter.FilterChar(model.Title);
                db.Post.Add(model);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Post.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {

                model.ModifierDate = DateTime.Now;
                model.Alias = cellphonesweb.Models.Commons.Filter.FilterChar(model.Title);
                db.Post.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Post.Find(id);
            if (item != null)
            {
                db.Post.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = true });
        }
    }
}
