using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public string? Address1 { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Landline { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Customer? CustomerNavigation { get; set; }
    }
}
