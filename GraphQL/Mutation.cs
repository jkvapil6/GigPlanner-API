 using System.Threading.Tasks;
 using GigPlanner.GraphQL.Data;
 using HotChocolate;

 namespace GigPlanner.GraphQL
 {
     public class Mutation
     {
        [UseApplicationDbContext]
         public async Task<AddGenrePayload> AddGenreAsync(
             AddGenreInput input,
             [Service] ApplicationDbContext context)
         {
             var genre = new Genre
             {
                 Name = input.Name
             };

             context.Genres.Add(genre);
             await context.SaveChangesAsync();

             return new AddGenrePayload(genre);
         }
     }
 }