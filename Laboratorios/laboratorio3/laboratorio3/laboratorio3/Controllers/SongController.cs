using laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;
namespace laboratorio3.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            var song = GetSong();
            ViewBag.MainTitle = "Mi cancion preferida";
            return View(song);
        }
        private SongModel GetSong()
        {
            SongModel song = new SongModel();
            song.Name = "Perfect";
            song.Singer = "Ed Sheeran";
            song.Genre = "Pop/Balada romántica";
            song.ViewsYoutube = 340800509;
            song.ReleaseDate = new DateTime(2017, 9, 8);

            return song;
        }
    }
}
