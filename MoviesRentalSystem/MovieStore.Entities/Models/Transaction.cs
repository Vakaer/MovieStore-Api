using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RentalId { get; set; }
        public int TransactionTypeId { get; set; }
        public string? TransactionComment { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? TransactionAmount { get; set; }

        public virtual Account IdNavigation { get; set; } = null!;
        public virtual TransactionType? TransactionType { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
