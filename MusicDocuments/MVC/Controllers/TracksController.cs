using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;
using MusicRepository;
using MVC.Models;

namespace MVC.Controllers
{
  
    public class TracksController : Controller
    {
        private TrackRepository trackRepository=new TrackRepository();
        private ArtistRepository artistRepository=new ArtistRepository();
        private GenreRepository genreRepository=new GenreRepository();
        private AlbumRepository albumRepository=new AlbumRepository();

        // GET: Tracks
        public ActionResult Index()
        {
            List<Track> tracks=trackRepository.GetAllTracks();
            List<TrackDetailsTemplate> trackDetails=new List<TrackDetailsTemplate>();

            int i = 0;
            foreach (var t in tracks)
            {
                TrackDetailsTemplate template=new TrackDetailsTemplate();
                template.Track = t;
                template.Artists = trackRepository.GetArtistsOfTrack(t.Id);
                template.Albums = trackRepository.GetAlbumsOfTrack(t.Id);
                template.Genres = trackRepository.GetGenresOfTrack(t.Id);
                trackDetails.Add(template);
                i++;
            }
            ViewBag.Tracks = trackDetails;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = trackRepository.GetTrackById(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.Artists = trackRepository.GetArtistsOfTrack(id);
            ViewBag.Genres = trackRepository.GetGenresOfTrack(id);
            ViewBag.Albums = trackRepository.GetAlbumsOfTrack(id);
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            ViewBag.Artists = new MultiSelectList(artistRepository.GetAllArtists(), "Id", "Name");
            ViewBag.Genres = new MultiSelectList(genreRepository.GetAllGenres(), "Id", "Name");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Track,Artists,Genres")] TrackEditTemplate template)
        {
            if (ModelState.IsValid)
            {
               trackRepository.CreateTrack(template.Track);
               trackRepository.UpdateArtistsOfTrack(template.Track.Id,template.Artists);
               trackRepository.UpdateGenresOfTrack(template.Track.Id,template.Genres);
                return RedirectToAction("Index");
            }
            ViewBag.Artists = new MultiSelectList(artistRepository.GetAllArtists(), "Id", "Name", template.Artists);
            ViewBag.Genres = new MultiSelectList(genreRepository.GetAllGenres(), "Id", "Name", template.Genres);
            return View(template);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = trackRepository.GetTrackById(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.Artists = new MultiSelectList(artistRepository.GetAllArtists(), "Id", "Name",trackRepository.GetArtistsOfTrack(id.Value).Select(a=>a.Id));
            ViewBag.Genres = new MultiSelectList(genreRepository.GetAllGenres(), "Id", "Name",trackRepository.GetGenresOfTrack(id.Value).Select(a => a.Id));
            ViewBag.Albums = trackRepository.GetAlbumsOfTrack(id.Value);
            TrackEditTemplate template=new TrackEditTemplate();
            template.Track = track;
            return View(template);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Track,Artists,Genres")] TrackEditTemplate template)
        {
            if (ModelState.IsValid)
            {
                trackRepository.UpdateTrack(template.Track);
                trackRepository.UpdateArtistsOfTrack(template.Track.Id,template.Artists);
                trackRepository.UpdateGenresOfTrack(template.Track.Id,template.Genres);
                return RedirectToAction("Index");
            }
            return View(template);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = trackRepository.GetTrackById(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trackRepository.DeleteTrackById(id);
            return RedirectToAction("Index");
        }

    }
}
