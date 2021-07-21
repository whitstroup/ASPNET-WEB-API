using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Mock_BestBuy_API
{
    public class EmployeeRepo : IEmployeeRepo
    {
       
        private readonly IDbConnection _connection;

        public EmployeeRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _connection.Query<Employee>("SELECT * FROM bestbuy.employees;");
        }

        public Employee GetEmployee(int id)
        {
            return _connection.QuerySingleOrDefault<Employee>("SELECT * FROM bestbuy.employees WHERE EmployeeID = @id;", new { id = id });
        }

        public void InsertEmployee(Employee emp)
        {
            _connection.Execute("INSERT INTO bestbuy.Employees(FirstName, LastName, Title, EmailAddress, PhonNumber)" +
                                "VALUES (@firstname, @lastname, @title, @email, @phone);",
            new { firstname = emp.FirstName, lastname = emp.LastName, title = emp.Title, email= emp.EmailAddress, phone = emp.PhoneNumber });
        }

        public void UpdateEmployee(Employee emp)
        {
            _connection.Execute("UPDATE bestbuy.employees SET FirstName = @firstname, LastName = @lastname, Title = @title, EmailAddress = @email, PhoneNumber = @phonenumber WHERE EmployeeID = @id",
                new { firstname = emp.FirstName, lastname = emp.LastName, title = emp.Title, id = emp.EmployeeID, email = emp.EmailAddress, phonenumber = emp.PhoneNumber});
        }

        public void DeleteEmployee(Employee emp)
        {
            _connection.Execute("DELETE from bestbuy.Employees WHERE EmployeeID = @id", new { id = emp.EmployeeID });
            _connection.Execute("DELETE from bestbuy.Sales WHERE EmployeeID = @id", new { id = emp.EmployeeID });
           
        }

        
    }
}
