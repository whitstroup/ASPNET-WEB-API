using System;
using Microsoft.AspNetCore.Mvc;

namespace Mock_BestBuy_API
{
    public class Employee
    {
        public Employee()
        {
        }

        public int EmployeeID { get; set; }

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string FullName { get { return $"{FirstName} + {LastName}"; } }
        
        public string Title { get; set; }
       
        public string EmailAddress { get; set; }
        
        public string PhoneNumber { get; set; }

    }
}
