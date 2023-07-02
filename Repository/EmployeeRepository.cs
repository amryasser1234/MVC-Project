using ProjectOwn.Date;
using ProjectOwn.Models;
using ProjectOwn.Repository.Base;

namespace ProjectOwn.Repository
{
    public class EmployeeRepository : MainRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        private readonly AppDbContext _context;

        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
