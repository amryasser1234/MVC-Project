using ProjectOwn.Models;

namespace ProjectOwn.Repository.Base
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void setPayRoll(Employee employee);
        decimal getSalary(Employee employee);

    }
}
