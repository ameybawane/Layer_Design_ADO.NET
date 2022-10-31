using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Business.Entities;

namespace EMS.Business.Abstraction
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployee();
        public string AddEmp(Employee employee);
        public string UpdateEmp(Employee employee);
        public Employee GetEmpData(int id);
        public string DeleteEmp(int id);
    }
}
