using MVCAssesment.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace MVCAssesment.MVC.ModelHelpers
{
    public class EmployeeHelperSQL : IEmployeeHelperSQL
    {
        public IEnumerable<EmployeeSalaryDeptIndex> GetEmployeeWithRank()
        {
            List<EmployeeSalaryDeptIndex> employees = new List<EmployeeSalaryDeptIndex>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EmployeesWithRank", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employees.Add(new EmployeeSalaryDeptIndex()
                        {
                            Employee = new Models.Employee()
                            {
                                EmployeeId = int.Parse(dataReader["EmployeeId"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                DOJ = DateTime.Parse(dataReader["DOJ"].ToString()),
                                Address = dataReader["Address"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Mobile = dataReader["Mobile"].ToString()
                            },
                            DepartmentName = dataReader["DptName"].ToString(),
                            SalaryAmount = decimal.Parse(dataReader["SalaryAmount"].ToString()),
                            Rank = int.Parse(dataReader["Rank"].ToString())
                        });
                    }
                }
            }
            catch (ArgumentNullException aEx)
            {
                //Log ArgumentNullException Exception
                Debug.WriteLine($"{aEx.Message} \n{aEx.StackTrace}");
            }
            catch (FormatException fEx)
            {
                //Log Format Exception
                Debug.WriteLine($"{fEx.Message} \n{fEx.StackTrace}");
            }
            catch (OverflowException oEx)
            {
                //Log Overflow Exception
                Debug.WriteLine($"{oEx.Message} \n{oEx.StackTrace}");
            }
            catch (IndexOutOfRangeException iEx)
            {
                //Log IndexOutOfRangeException Exception
                Debug.WriteLine($"{iEx.Message} \n{iEx.StackTrace}");

            }
            catch (SqlException ex)
            {
                //Log Sql Exception
                Debug.WriteLine($"{ex.Message} \n{ex.StackTrace}");
            }


            return employees;
        }
    }
}