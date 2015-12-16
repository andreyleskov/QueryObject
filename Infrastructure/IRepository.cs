namespace Infrastructure
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }


}