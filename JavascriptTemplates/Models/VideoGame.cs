using System.Collections.Generic;

namespace JavascriptTemplates.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public Genres Genre { get; set; }
    }

    public class VideoGamesList
    {
        public List<VideoGame> VideoGames { get; set; }
        public List<string> Genres { get; set; }
    }
}
