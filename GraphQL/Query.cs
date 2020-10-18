using System.Linq;
using HotChocolate;
using GigPlanner.GraphQL.Data;

namespace GigPlanner.GraphQL
{
    public class Query
    {
        public IQueryable<Genre> GetGenres([Service] ApplicationDbContext context) =>
            context.Genres;
    }
}