namespace Transport_ly.Data.Interfaces
{

    public interface IRepository<T, U>
        where T : class
        where U : class
    {
        //These methods will be disabled, but they are kept for reference, since keeping them without a concrete implementation
        // only forces the creation of dummy methods which will throw 'not implemented exceptions'
        /*
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T Get(int id);
        */

        IEnumerable<T> GetCollection(U param);
    }

    public interface IRepositoryAsync<T, U>
        where T : class
        where U : class
    {
        Task<IEnumerable<T>> GetCollectionAsync(U param);

    }





}
