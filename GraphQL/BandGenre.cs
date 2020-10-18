namespace GigPlanner.GraphQL.Data
{
    public class BandGenre
    {
        public int BandId { get; set; }

        public Band? Band { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}