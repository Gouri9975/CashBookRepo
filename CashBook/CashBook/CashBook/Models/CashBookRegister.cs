using SQLite;
using System;

namespace CashBook.Models
{
    public class CashBookRegister
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal DRAmount { get; set; }

        public decimal CRAmount { get; set; }
    }
}