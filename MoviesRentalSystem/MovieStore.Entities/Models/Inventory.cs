using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int? NumberofDvd { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
