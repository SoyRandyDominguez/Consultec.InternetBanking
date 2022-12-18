using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IB.Domain.Entities
{
    public partial class TransactionType : IAuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
        public TransactionType()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
