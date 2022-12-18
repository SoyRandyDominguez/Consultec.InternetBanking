using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Entities.Base
{
    public class BaseEntity<T> : IBaseEntity<T> where T : struct
    {
        public virtual T? Id { get; }
    }
}
