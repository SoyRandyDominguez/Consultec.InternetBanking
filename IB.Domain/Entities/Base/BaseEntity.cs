namespace IB.Domain.Entities.Base
{
    public class BaseEntity<T> : IBaseEntity<T> where T : struct
    {
        public virtual T? Id { get; }
    }
}
