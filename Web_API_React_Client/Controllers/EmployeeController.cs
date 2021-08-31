using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_API_React_Client.Models;

namespace Web_API_React_Client.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeeController : ApiController
    {
        public List<Employee> GetAll()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{Id=101, Name="Balakrishna guddati", Location="Hyderabad",Salary=90000},
                 new Employee{Id=102, Name="Rama Raju", Location="Hyderabad",Salary=90000},
                  new Employee{Id=103, Name="raju", Location="Hyderabad",Salary=90000},
                   new Employee{Id=104, Name="akshay", Location="Hyderabad",Salary=90000},
                    new Employee{Id=105, Name="krishna", Location="Hyderabad",Salary=90000},
            };
            return empList;
        }

        public bool Post(Employee employee)
        {
            SqlConnection conn = new SqlConnection(@"server=LAPTOP-J6GR3UI9\MSSQLSERVER2;database=ReactAppDB;Integrated Security=SSPI;Persist Security Info=False;");
            string query = "insert into EmployeeInfo values(@Id,@Name,@Loc,@Sal)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@Loc", employee.Location));
            cmd.Parameters.Add(new SqlParameter("@Sal", employee.Salary));
            int noOfRowsAffected;
            try { 
            conn.Open();
             noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }
            return noOfRowsAffected > 0 ? true : false;
        }
    }
}
