 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using GigPlanner.GraphQL.Data;
 using GreenDonut;
 using HotChocolate.DataLoader;

 namespace GigPlanner.GraphQL.DataLoader
 {
     public class GenreByIdDataLoader : BatchDataLoader<int, Genre>
     {
         private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

         public GenreByIdDataLoader(
             IBatchScheduler batchScheduler, 
             IDbContextFactory<ApplicationDbContext> dbContextFactory)
             : base(batchScheduler)
         {
             _dbContextFactory = dbContextFactory ?? 
                 throw new ArgumentNullException(nameof(dbContextFactory));
         }

         protected override async Task<IReadOnlyDictionary<int, Genre>> LoadBatchAsync(
             IReadOnlyList<int> keys, 
             CancellationToken cancellationToken)
         {
             await using ApplicationDbContext dbContext = 
                 _dbContextFactory.CreateDbContext();

             return await dbContext.Genres
                 .Where(s => keys.Contains(s.Id))
                 .ToDictionaryAsync(t => t.Id, cancellationToken);
         }
     }
 }