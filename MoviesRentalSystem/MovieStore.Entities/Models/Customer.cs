using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public string? RentalCosts { get; set; }
        public string? Email { get; set; }
        public int AccountId { get; set; }
        public int TransactionId { get; set; }
        public int RentalId { get; set; }
        public int AddressId { get; set; }

        public virtual Account AccountNavigation { get; set; } = null!;
        public virtual Rental Id1 { get; set; } = null!;
        public virtual Address IdNavigation { get; set; } = null!;
        public virtual Transaction Transaction { get; set; } = null!;
        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }
    }
}
