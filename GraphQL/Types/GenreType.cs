 using System.Collections.Generic;
 using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using GigPlanner.GraphQL.Data;
 using GigPlanner.GraphQL.DataLoader;
 using HotChocolate;
 using HotChocolate.Types;

 namespace GigPlanner.GraphQL.Types
 {
    public class GenreType : ObjectType<Genre>
     {
         protected override void Configure(IObjectTypeDescriptor<Genre> descriptor)
         {
             descriptor
                 .Field(t => t.BandGenres)
                 .ResolveWith<GenreResolvers>(t => t.GetBandsAsync(default!, default!, default!, default))
                 .UseDbContext<ApplicationDbContext>()
                 .Name("bands");
         }

         private class GenreResolvers
         {
             public async Task<IEnumerable<Band>> GetBandsAsync(
                 Genre genre,
                 [ScopedService] ApplicationDbContext dbContext,
                 BandByIdDataLoader bandById,
                 CancellationToken cancellationToken)
             {
                 int[] genreIds = await dbContext.Genres
                     .Where(g => g.Id == genre.Id)
                     .Include(g => g.BandGenres)
                     .SelectMany(g => g.BandGenres.Select(t => t.BandId))
                     .ToArrayAsync();

                 return await bandById.LoadAsync(genreIds, cancellationToken);
             }
         }
     }
 }