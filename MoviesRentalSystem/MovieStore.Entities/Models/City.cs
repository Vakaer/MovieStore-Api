using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Lastupdated { get; set; }

        public virtual Address? Address { get; set; }
    }
}
