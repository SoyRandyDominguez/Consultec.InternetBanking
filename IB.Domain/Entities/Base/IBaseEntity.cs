namespace IB.Domain.Entities.Base
{
    public interface IBaseEntity<T> where T : struct
    {
        T? Id { get; }
    }
}
