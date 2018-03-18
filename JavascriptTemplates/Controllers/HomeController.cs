using System;
using System.Collections.Generic;
using System.Linq;
using JavascriptTemplates.Models;
using Microsoft.AspNetCore.Mvc;

namespace JavascriptTemplates.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult NoTemplate()
        {
            return View(VideoGames());
        }

        [HttpGet]
        public IActionResult WithTemplate()
        {
            return View(VideoGames());
        }


        private VideoGamesList VideoGames()
        {
            var list = new List<VideoGame>
            {
                new VideoGame
                {
                    Id = 1,
                    Name = "Metal Gear Solid",
                    Genre = Genres.Stealth_Shooter,
                    StarRating = 3
                },
                new VideoGame
                {
                    Id = 2,
                    Name = "Portal 2",
                    Genre = Genres.Puzzle,
                    StarRating = 3
                },
                new VideoGame
                {
                    Id = 3,
                    Name = "Last of Us",
                    Genre = Genres.Adventure,
                    StarRating = 3
                },
                new VideoGame
                {
                    Id = 4,
                    Name = "Doom",
                    Genre = Genres.Fps,
                    StarRating = 2
                },
                new VideoGame
                {
                    Id = 5,
                    Name = "Sim City",
                    Genre = Genres.Simulation,
                    StarRating = 1
                }
            };
            return new VideoGamesList
            {
                VideoGames = list,
                Genres = Enum.GetNames(typeof(Genres)).ToList()
            };
        }
    }
}
