using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository objEmployee;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.objEmployee = repo;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return objEmployee.GetAllEmployee();
        }

        [HttpGet]
        public Employee GetById(int id)
        {
            return objEmployee.GetEmpData(id);
        }

        [HttpPost]
        public string Add([FromBody] Employee employee)
        {
            return objEmployee.AddEmp(employee);
        }

        [HttpPut]
        public string Edit([FromBody] Employee employee)
        {
            return objEmployee.UpdateEmp(employee);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return objEmployee.DeleteEmp(id);
        }
    }

}