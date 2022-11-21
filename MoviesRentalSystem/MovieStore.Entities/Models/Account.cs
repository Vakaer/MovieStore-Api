using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountDetails { get; set; }
        public string? BankName { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Rental Customer { get; set; } = null!;
        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual Transaction? Transaction { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
