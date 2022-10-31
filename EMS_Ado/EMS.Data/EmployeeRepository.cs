using EMS.Business.Abstraction;
using EMS.Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace EMS.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connectionString = "Server=IN-LT-SPARE09\\SQL2019;Database=EmployeeDb;" +
               "Trusted_Connection=True;MultipleActiveResultSets=True;";

        public string AddEmp(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddEmp_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Employee added successfully.";
            }
            catch
            {
                throw;
            }
        }

        public string DeleteEmp(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DelEmp_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Employee deleted successfully.";
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                List<Employee> listEmployee = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("GetAllEmp_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employee employee = new Employee();

                        employee.Id = Convert.ToInt32(rdr["Id"]);
                        employee.FirstName = rdr["FirstName"].ToString();
                        employee.LastName = rdr["LastName"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Designation = rdr["Designation"].ToString();
                        listEmployee.Add(employee);
                    }
                    con.Close();
                }
                return listEmployee;
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmpData(int id)
        {
            try
            {
                Employee employee = new Employee();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM EmployeeTbl WHERE Id = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.Id = Convert.ToInt32(rdr["Id"]);
                        employee.FirstName = rdr["FirstName"].ToString();
                        employee.LastName = rdr["LastName"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Designation = rdr["Designation"].ToString();
                    }
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateEmp(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmp_sp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id ", employee.Id);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Employee updated successfully.";
            }
            catch
            {
                throw;
            }
        }
    }
}