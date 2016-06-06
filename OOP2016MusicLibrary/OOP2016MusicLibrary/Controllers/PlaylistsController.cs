using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using OOP2016MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Playlists/
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var UserPlaylists = db.Playlists.Where(c => c.User.Id == id);
            return View(UserPlaylists.ToList());
        }

        // GET: /Playlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            var userid = User.Identity.GetUserId();
            if (playlist.User.Id != userid)
            {
                return RedirectToAction("Index");
            }
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // GET: /Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                playlist.User = db.Users.Find(id);
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playlist);
        }

        // GET: /Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            var userid = User.Identity.GetUserId();
            if (playlist.User.Id != userid)
            {
                return RedirectToAction("Index");
            }
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: /Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }

        // GET: /Playlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            var userid = User.Identity.GetUserId();
            if (playlist.User.Id != userid)
            {
                return RedirectToAction("Index");
            }
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: /Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
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