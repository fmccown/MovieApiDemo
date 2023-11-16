using Newtonsoft.Json;
using System.Collections.Generic;

namespace UWP_MovieApiDemo
{
    public class Movie
    {
        // Subset of fields from the API

        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }        
        public string Metascore { get; set; }

        [JsonProperty(PropertyName = "imdbRating")]
        public double ImdbRating { get; set; }

        [JsonProperty(PropertyName = "imdbVotes")]
        public string ImdbVotes { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
