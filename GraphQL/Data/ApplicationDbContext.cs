 using Microsoft.EntityFrameworkCore;

 namespace GigPlanner.GraphQL.Data
 {
     public class ApplicationDbContext : DbContext
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
         {
         }

         public DbSet<Genre> Genres { get; set; } = default!;
     }
 }