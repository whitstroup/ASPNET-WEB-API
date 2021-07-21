using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mock_BestBuy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepo repo;

        public EmployeeController(IEmployeeRepo _repo)
        {
            repo = _repo;
        }
        // GET: /<controller>/
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = repo.GetAllEmployees();


            return Ok(JsonConvert.SerializeObject(employees));
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = repo.GetEmployee(id);



            return Ok(JsonConvert.SerializeObject(employee));
        }

        [HttpPost]
        public void CreateEmployee(Employee emp)
        {

            var lastEmpployeeID = repo.GetAllEmployees().Last().EmployeeID;
            emp.EmployeeID = lastEmpployeeID++;

            repo.InsertEmployee(emp);
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, Employee emp)
        {
            emp.EmployeeID = id;

            repo.UpdateEmployee(emp);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var emp = repo.GetEmployee(id);

            repo.DeleteEmployee(emp);
        }

    }
}