using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IB.Domain.Entities
{
    public partial class Account :IAuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public long AccountNumber { get; set; }
        public int ClientId { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public Account()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
