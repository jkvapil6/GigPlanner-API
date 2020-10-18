using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigPlanner.GraphQL.Data;
using GigPlanner.GraphQL.DataLoader;

namespace GigPlanner.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Genre>> GetGenres([ScopedService] ApplicationDbContext context) =>
            context.Genres.ToListAsync();

        public Task<Genre> GetGenreAsync(
            int id,
            GenreByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}