using IB.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IB.Domain.Entities
{
    public partial class AccountType : IAuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
        public AccountType()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
