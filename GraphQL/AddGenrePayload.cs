 using GigPlanner.GraphQL.Data;

 namespace GigPlanner.GraphQL
 {
     public class AddGenrePayload
     {
         public AddGenrePayload(Genre genre)
         {
             Genre = genre;
         }

         public Genre Genre { get; }
     }
 }