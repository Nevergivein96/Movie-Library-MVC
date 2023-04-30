namespace Movie_Library_MVC.Models
{
    public class Movie
    {
        public Movie() { }
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string GenreName { get; set; }
        public string Rating { get; set; }   
        public int RatingScale { get; set; } 
        public string SeriesOrMovie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }

    }
}
