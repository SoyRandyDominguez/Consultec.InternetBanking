using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Entities
{
    public partial class Client : BaseEntity<int>, IAuditEntity
    {
        public override int? Id => base.Id;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
        public Client()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
