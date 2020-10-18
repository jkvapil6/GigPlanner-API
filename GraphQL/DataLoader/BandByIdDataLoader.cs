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
     public class BandByIdDataLoader : BatchDataLoader<int, Band>
     {
         private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

         public BandByIdDataLoader(
             IBatchScheduler batchScheduler, 
             IDbContextFactory<ApplicationDbContext> dbContextFactory)
             : base(batchScheduler)
         {
             _dbContextFactory = dbContextFactory ?? 
                 throw new ArgumentNullException(nameof(dbContextFactory));
         }

         protected override async Task<IReadOnlyDictionary<int, Band>> LoadBatchAsync(
             IReadOnlyList<int> keys, 
             CancellationToken cancellationToken)
         {
             await using ApplicationDbContext dbContext = 
                 _dbContextFactory.CreateDbContext();
             
             return await dbContext.Bands
                 .Where(b => keys.Contains(b.Id))
                 .ToDictionaryAsync(t => t.Id, cancellationToken);
         }
     }
 }