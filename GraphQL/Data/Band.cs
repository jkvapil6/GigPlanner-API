using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigPlanner.GraphQL.Data
{
    public class Band
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Website { get; set; }

        public ICollection<BandGenre> BandGenres { get; set; } = 
          new List<BandGenre>();
    }
}