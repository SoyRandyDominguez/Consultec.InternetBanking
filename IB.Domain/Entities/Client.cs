using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IB.Domain.Entities
{
    public partial class Client : IAuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public Client()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
