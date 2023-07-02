using ProjectOwn.Models;

namespace ProjectOwn.Repository.Base
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository <Category> Categories { get; }
        IEmployeeRepository Employees { get; }
        IRepository<Items> Items { get; }
        int CommitChanges(); 
    }
}
