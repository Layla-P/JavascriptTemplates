

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavascriptTemplates.Database;
using JavascriptTemplates.Models;
using Microsoft.AspNetCore.Mvc;

namespace JavascriptTemplates.Controllers
{
    [Route("api/[controller]")]
    public class SeedController : Controller
    {
        private readonly IVideoGameRepository _videoGameRepository;


        public SeedController(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }



        [HttpGet("cleanup")]
        public async Task<IActionResult> CleanUpAsync()
        {
            await _videoGameRepository.DeleteAllAsync();

            foreach (var item in VideoGames())
            {
                await _videoGameRepository.AddAsync(item);
                //TODO refactor to WhenAll
            }

            return Ok();
        }


        private static List<VideoGame> VideoGames()
        {
            return new List<VideoGame>
            {
                new VideoGame
                {
                    Name = "Metal Gear Solid",
                    Genre = Genres.Stealth_Shooter,
                    StarRating = 3
                },
                new VideoGame
                {
                    Name = "Portal 2",
                    Genre = Genres.Puzzle,
                    StarRating = 3
                },
                new VideoGame
                {
                    Name = "Last of Us",
                    Genre = Genres.Adventure,
                    StarRating = 3
                },
                new VideoGame
                {
                    Name = "Doom",
                    Genre = Genres.Fps,
                    StarRating = 2
                },
                new VideoGame
                {
                    Name = "Sim City",
                    Genre = Genres.Simulation,
                    StarRating = 1
                }
            };

        }


    }
}
