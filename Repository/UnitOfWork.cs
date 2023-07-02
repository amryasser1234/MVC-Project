using ProjectOwn.Date;
using ProjectOwn.Models;

namespace ProjectOwn.Repository.Base
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork (AppDbContext context) 
        { 
            _context= context;  
            Categories = new MainRepository<Category>(_context);
            Employees = new EmployeeRepository(_context);
            Items = new MainRepository<Items>(_context);
        }
        private readonly AppDbContext _context;

        public IRepository<Category> Categories { get; private set; }    

        public IEmployeeRepository Employees { get; private set; }

        public IRepository<Items> Items { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
