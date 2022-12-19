using IB.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IB.Domain.Entities
{
    public partial class User : IAuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }
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
