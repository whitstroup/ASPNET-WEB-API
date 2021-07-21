using System;
using System.Collections.Generic;

namespace Mock_BestBuy_API
{
    public interface IEmployeeRepo
    {

        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void InsertEmployee(Employee emp);
        public void UpdateEmployee(Employee emp);
        public void DeleteEmployee(Employee emp);
    }
}
