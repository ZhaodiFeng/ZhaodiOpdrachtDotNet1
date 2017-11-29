using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using MusicRepository;

namespace MVC.Models
{
    public class TrackDetailsTemplate
    {
        public Track Track { get; set; }
        public List<Artist> Artists { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Album> Albums { get; set; }

        public TrackDetailsTemplate()
        {
            Artists = new List<Artist>();
            Genres=new List<Genre>();
            Albums = new List<Album>();
        }
    }
}