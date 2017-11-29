using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using MusicRepository;

namespace MVC.Models
{
    public class AlbumEditTemplate
    {
        public Album Album { get; set; }
        public List<int> Publishers { get; set; }
        public List<AlbumTracksTemplate> Tracks { get; set; }


    }
}