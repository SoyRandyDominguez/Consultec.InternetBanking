using System;

namespace IB.Domain.Entities.Base
{
    public interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }
        string CreatedByUser { get; set; }
        DateTime? UpdatedAt { get; set; }
        string UpdatedByUser { get; set; }
    }
}
