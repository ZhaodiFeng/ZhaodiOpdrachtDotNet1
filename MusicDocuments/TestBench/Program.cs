using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicRepository;

namespace TestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            var data=new TrackRepository().GetArtistsOfTrack(2);
            Console.WriteLine();
        }
    }
}
