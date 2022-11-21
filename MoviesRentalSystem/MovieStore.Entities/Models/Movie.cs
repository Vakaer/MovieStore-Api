using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public int? GenreId { get; set; }
        public int? ReleaseYearId { get; set; }
        public int? DirectorId { get; set; }
        public int? RentalCost { get; set; }
        public int? ProducerId { get; set; }
        public int? LanguageId { get; set; }

        public virtual Director? Director { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Language? Language { get; set; }
        public virtual Producer? Producer { get; set; }
        public virtual ReleaseYear? ReleaseYear { get; set; }
        public virtual Rental? Rental { get; set; }
    }
}
