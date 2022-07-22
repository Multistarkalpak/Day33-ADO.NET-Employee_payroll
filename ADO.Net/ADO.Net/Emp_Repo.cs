using ADO.Net;
using System;
using System.Collections.Generic;
using System.Data;
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
        public void AddEmployee(Employee_Payroll model)
        {
            try
            {
                Connection = new SqlConnection(ConncetionString);
                SqlCommand command = new SqlCommand("dbo.spAddEmployee", Connection);
                command.CommandType = CommandType.StoredProcedure;

                //command.Parameters.AddWithValue("@EmployeeName", model.EmployeeID);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Department", model.Department);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Phone", model.Phone);
                command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                command.Parameters.AddWithValue("@StartDate", model.StartDate);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                command.Parameters.AddWithValue("@NetPay", model.NetPay);
                command.Parameters.AddWithValue("@IncomeTax", model.IncomTax);
                command.Parameters.AddWithValue("@Deductions", model.Deductions);



                this.Connection.Open();
                var result = command.ExecuteNonQuery();
                this.Connection.Close();
                if (result != 0)
                {
                    Console.WriteLine("employee inserted suceesfully into table");
                }
                else
                {
                    Console.WriteLine("Not interested");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();

            }
        }

        public void UpdateEmployee(Employee_Payroll model)
        {
            try
            {

                Connection = new SqlConnection(ConncetionString);
                SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                command.Parameters.AddWithValue("@Name", model.Name);
                this.Connection.Open();
                var result = command.ExecuteNonQuery();
                this.Connection.Close();
                if (result != 0)
                {
                    Console.WriteLine("employee updates suceesfully into table");
                }
                else
                {
                    Console.WriteLine("Not interested");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();

            }

        }
        public void DeleteEmployee(Employee_Payroll model)
        {
            try
            {

                Connection = new SqlConnection(ConncetionString);
                SqlCommand command = new SqlCommand("dbo.spDeleteEmployee", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                this.Connection.Open();
                var result = command.ExecuteNonQuery();
                this.Connection.Close();
                if (result != 0)
                {
                    Console.WriteLine("employee deleted suceesfully into table");
                }
                else
                {
                    Console.WriteLine("Not interested");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();

            }

        }

        public void InsertIntoTwoTables(Employee_Payroll model)
        {
            try
            {
                Connection = new SqlConnection(ConncetionString);
                SqlCommand command = new SqlCommand("spInsertIntoTwoTables", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                this.Connection.Open();
                var result = command.ExecuteScalar();
                string EmployeeID = command.Parameters["@EmployeeID"].Value.ToString();
                int newid = Convert.ToInt32(EmployeeID);

                string query = $"insert into Salary (EmployeeID,OTSaraly) values({newid},{model.BasicPay})";
                SqlCommand Comd = new SqlCommand(query, Connection);
                int res = command.ExecuteNonQuery();
                if (res != 0)
                {
                    Console.WriteLine("employee inserted suceesfully into table");
                }
                else
                {
                    Console.WriteLine("Not interested");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally

            {
                Connection.Close();
            }

        }

        public void RetrivetheEmployeeAccordingToDateRange(Employee_Payroll model)
        {
            try
            {
                using (Connection = new SqlConnection(ConncetionString))
                {

                    Employee_Payroll employee = new Employee_Payroll();
                    String Query = "SELECT * FROM  EmployeeTable where StartDate between CAST('2017-04-01' as date) and GETDATE();";
                    //sqlcommand class provide multiple commad methods
                    SqlCommand command = new SqlCommand(Query, Connection);
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //sqlreader provides a way to readind a stream from sql server it is also not inherited
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {//here if teh data is null we are replacing with the defult values
                         //or it will read the dta from tha specified row
                            employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"] == DBNull.Value ? default : reader["EmployeeID"]);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}