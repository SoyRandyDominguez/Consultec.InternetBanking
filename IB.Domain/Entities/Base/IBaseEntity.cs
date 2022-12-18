using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Entities.Base
{
    public interface IBaseEntity<T> where T : struct
    {
        T? Id { get; }
    }
}
