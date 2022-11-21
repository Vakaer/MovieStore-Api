using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Lastupdated { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
