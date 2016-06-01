using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OOP2016MusicLibrary.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace OOP2016MusicLibrary.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Songs/
        public ActionResult Index(int id2 = 0)
        {
            var songs = db.Songs.Where(c => c.playlistId == id2);
            ViewBag.id2 = id2;
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index","Playlists");
            }
            //var songs = db.Songs.Include(s => s.Playlist);
            return View(songs.ToList());
        }

        // GET: /Songs/Details/5
        public ActionResult Details(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index", "Playlists");
            }
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.id2 = id2;

            return View(song);
        }

        // GET: /Songs/Create
        public ActionResult Create(int id2 = 0)
        {
            ViewBag.playlistId = new SelectList(db.Playlists, "id", "name");
            ViewBag.id2 = id2;
            ViewBag.playlistName = db.Playlists.Find(id2).name;
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index", "Playlists");
            }
            return View();
        }

        // POST: /Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,songName,artist,imageSrc,fileSrc,playlistId")] Song song, int id2 = 0)
        {
            if (ModelState.IsValid)
            {

                song.Playlist = db.Playlists.Find(id2);
                song.playlistId = id2;
                db.Songs.Add(song);
                db.SaveChanges();

                return RedirectToAction("Index", new { id2 = id2});
            }

            ViewBag.playlistId = new SelectList(db.Playlists, "id", "name");
            ViewBag.id2 = id2;
            ViewBag.playlistId = new SelectList(db.Playlists, "id", "name", song.playlistId);
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index", "Playlists");
            }
            return View(song);
        }

        // GET: /Songs/Edit/5
        public ActionResult Edit(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.id2 = id2;
            ViewBag.playlistName = db.Playlists.Find(id2).name;
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index", "Playlists");
            }
            return View(song);
        }

        // POST: /Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,songName,artist,imageSrc,fileSrc,playlistId")] Song song, int id2=0)
        {
            if (ModelState.IsValid)
            {
                song.Playlist = db.Playlists.Find(id2);
                song.playlistId = id2;
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id2 = id2});
            }

            ViewBag.id2 = id2;
            ViewBag.playlistName = db.Playlists.Find(id2).name;
            ViewBag.playlistId = new SelectList(db.Playlists, "id", "name", song.playlistId);
            return View(song);
        }

        // GET: /Songs/Delete/5
        public ActionResult Delete(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.id2 = id2;
            Playlist thisPlaylist = db.Playlists.Find(id2);
            var UserId = User.Identity.GetUserId();

            if (thisPlaylist.User.Id != UserId)
            {
                return RedirectToAction("Index", "Playlists");
            }
            return View(song);
        }

        // POST: /Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,int id2 = 0)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index", new { id2 = id2});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("UploadDocument");
        }
    }
}
