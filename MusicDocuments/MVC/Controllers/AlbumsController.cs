using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DAL;
using Microsoft.Ajax.Utilities;
using Model;
using MusicRepository;
using MVC.Models;

namespace MVC.Controllers
{
    public class AlbumsController : Controller
    {
        private AlbumRepository albumRepository=new AlbumRepository();
        private TrackRepository trackRepository=new TrackRepository();
        private PublisherRepository publisherRepository=new PublisherRepository();

        // GET: Albums
        public ActionResult Index()
        {
            return View(albumRepository.GetAllAlbums());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.Publishers = albumRepository.GetPublishersOfAlbum(id);
            ViewBag.Tracks = albumRepository.GetTracksOfAlbum(id).OrderBy(t=>t.Sequnce).ToList();
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.Publishers = new MultiSelectList(publisherRepository.GetAllPublishers(),"Id","Name");
            ViewBag.TracksList = new SelectList(trackRepository.GetAllTracks(),"Id","Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Album,Publishers,Tracks")] AlbumEditTemplate template)
        {
            if (ModelState.IsValid)
            {
               albumRepository.CreateAlbum(template.Album);
               albumRepository.UpdatePublishersOfAlbum(template.Album.Id,template.Publishers);
               albumRepository.UpdateTracksOfAlbum(template.Album.Id,template.Tracks);
               return RedirectToAction("Index");
            }
            ViewBag.Publishers = new MultiSelectList(publisherRepository.GetAllPublishers(), "Id", "Name",template.Publishers);
            ViewBag.TracksList= new SelectList(trackRepository.GetAllTracks(), "Id", "Name",template.Tracks.Select(t=>t.Track));
            return View(template);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            AlbumEditTemplate template = new AlbumEditTemplate();
            template.Album = album;
            template.Publishers = albumRepository.GetPublishersOfAlbum(id).Select(p=>p.Id).ToList();
            template.Tracks = albumRepository.GetTracksOfAlbum(id);
            
            ViewBag.Publishers = new MultiSelectList(publisherRepository.GetAllPublishers(), "Id", "Name");
            ViewBag.TracksList = new SelectList(trackRepository.GetAllTracks(), "Id", "Name");
            return View(template);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Album,Publishers,Tracks")] AlbumEditTemplate template)
        {
            if (ModelState.IsValid)
            {
                albumRepository.UpdateAlbum(template.Album);
                albumRepository.UpdatePublishersOfAlbum(template.Album.Id,template.Publishers);
                albumRepository.UpdateTracksOfAlbum(template.Album.Id,template.Tracks);
                return RedirectToAction("Index");
            }
            ViewBag.Publishers = new MultiSelectList(publisherRepository.GetAllPublishers(), "Id", "Name", template.Publishers);
            ViewBag.TracksList = new SelectList(trackRepository.GetAllTracks(), "Id", "Name", template.Tracks.Select(t => t.Track).ToList());
            return View(template);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            albumRepository.DeletAlbumById(id);
            return RedirectToAction("Index");
        }

      
    }
}
