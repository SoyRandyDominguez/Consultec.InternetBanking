using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Entities
{
    public partial class User : BaseEntity<int>, IAuditEntity
    {
        public override int? Id => base.Id;
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }

        public virtual Client Client { get; set; }

        public User()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
