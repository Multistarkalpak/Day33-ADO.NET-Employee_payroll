using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO.Net
{
    public class Employee_Payroll
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public float BasicPay { get; set; }
        public string StartDate { get; set; }
        public string Gender { get; set; }
        public float TaxablePay { get; set; }
        public float NetPay { get; set; }
        public float IncomTax { get; set; }
        public double Deductions { get; set; }
    }
}
    

