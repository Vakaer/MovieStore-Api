using System;
using System.Collections.Generic;

namespace MovieStore.Main.Models
{
    public partial class TransactionType
    {
        public int Id { get; set; }
        public string? TransactipnTypeDescription { get; set; }

        public virtual Transaction IdNavigation { get; set; } = null!;
    }
}
