using System.Linq.Expressions;

namespace ProjectOwn.Repository.Base
{
    public interface IRepository<T> where T : class 
    {
        T GetById(int id);

        T SelectOne(Expression<Func<T, bool>> Match);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] agers);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params string[] agers);
        void AddOne(T MyItem);
        void UpdateOne(T MyItem);
        void DeleteOne(T MyItem);
        void AddList(IEnumerable<T> MyList);
        void UpdateList(IEnumerable<T> MyList);
        void DeleteList(IEnumerable<T> MyList);

    }
}
