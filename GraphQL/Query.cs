using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigPlanner.GraphQL.Data;

namespace GigPlanner.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Genre>> GetGenres([ScopedService] ApplicationDbContext context) =>
            context.Genres.ToListAsync();
    }
}