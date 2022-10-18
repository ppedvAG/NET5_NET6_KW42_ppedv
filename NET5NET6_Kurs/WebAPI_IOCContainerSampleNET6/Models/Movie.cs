namespace WebAPI_IOCContainerSampleNET6.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public decimal Price { get; set; }
        public GenreTyp Genre { get; set; }
    }


    public enum GenreTyp { Action, Comedy, Thriller, Romance, Drama, History, ScienceFiction, Docu}
}
