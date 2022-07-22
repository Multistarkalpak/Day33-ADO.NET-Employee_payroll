
using ADO.Net;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetEmployeeProblem
{
    public class EmployeeRepository
    {
        
        public static string ConncetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll;Integrated Security=True;";
        SqlConnection Connection = null;
     
        public void GetAllEmployees()
        {
            try
            {
             
                using (Connection = new SqlConnection(ConncetionString))
                {
                    Employee_Payroll employee = new Employee_Payroll();
                    String Query = "select * from EmployeeTable";
                   
                    SqlCommand command = new SqlCommand(Query, Connection);
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                   
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                         
                            employee.EmployeeID=Convert.ToInt32(reader["EmployeeID"]==DBNull.Value ? default : reader["EmployeeID"]);
                            employee.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            employee.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            employee.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            employee.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            employee.StartDate = reader["StartDate"] == DBNull.Value ? default : reader["StartDate"].ToString();
                            employee.Phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            employee.BasicPay = Convert.ToInt32(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            employee.TaxablePay = Convert.ToInt32(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            employee.NetPay = Convert.ToInt32(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            employee.IncomTax = Convert.ToInt32(reader["IncomTax"] == DBNull.Value ? default : reader["IncomTax"]);
                            employee.Deductions = Convert.ToInt32(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employee.Name,
                                employee.EmployeeID, employee.Department, 
                                employee.Address, employee.Phone, employee.Gender, employee.BasicPay,
                                employee.Gender, employee.StartDate,
                                employee.TaxablePay, employee.NetPay, employee.IncomTax, employee.Deductions);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}