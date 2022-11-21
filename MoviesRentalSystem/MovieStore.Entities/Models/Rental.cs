using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? MovieId { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? Totalcost { get; set; }
        public int? TotalMoviesRented { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
