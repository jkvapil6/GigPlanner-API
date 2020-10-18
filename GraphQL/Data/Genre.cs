 using System.ComponentModel.DataAnnotations;

 namespace GigPlanner.GraphQL.Data
 {
     public class Genre
     {
         public int Id { get; set; }

         [Required]
         [StringLength(200)]
         public string? Name { get; set; }
     }
 }