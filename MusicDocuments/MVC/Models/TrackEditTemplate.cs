using System.Collections.Generic;
using Model;

namespace MVC.Models
{
    public class TrackEditTemplate
    {
        public Track Track { get; set; }
        public List<int> Artists { get; set; }
        public List<int> Genres { get; set; }
    }
}