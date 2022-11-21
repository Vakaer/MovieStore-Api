using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class ReleaseYear
    {
        public ReleaseYear()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime? Lastupdated { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
