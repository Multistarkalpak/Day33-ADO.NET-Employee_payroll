using ADO.Net;

namespace ADO.NetEmployeeProblem
{
    public class EmployeePayRollTests
    {
        EmployeeRepository employeeRepo;
        Employee_Payroll model;
        [SetUp]
        public void Setup()
        {
            Employee_Payroll model = new Employee_Payroll();
            EmployeeRepository employeeRepo = new EmployeeRepository();
        }
        [Test]
        public void CheckConnection()
        {
            EmployeeRepository emprepo = new EmployeeRepository();
            bool expect = emprepo.EstablishConnection();
            bool result = true;
            Assert.AreEqual(result, expect);
        }

        [Test]
        public void AbilityToAddTheNewEmployeeAndCompareWithObjectToDB()
        {
            //Arrange
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Employee_Payroll model = new Employee_Payroll();
            model.Name = "Karthika";
            model.Department = "HR";
            model.Address = "3rd main";
            model.Phone = 1234565432;
            model.BasicPay = 3000000;
            model.StartDate = "2004-09-08";
            model.Gender = "M";
            model.TaxablePay = 79000;
            model.NetPay = 6588;
            model.IncomTax = 5676;
            model.Deductions = 2345;

            //act

            bool actual = employeeRepo.AddEmployee(model);
            bool expected = true;
            Assert.AreEqual(actual, expected);

        }
        [Test]
        public void AbilityToCheckWeatherTheUpdatedEmployeePresentOrNotInDB()
        {
            //Arrange
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Employee_Payroll model = new Employee_Payroll();
            model.Name = "Gowri";
            //every time when i run it i have to change r else it will fail.
            model.BasicPay = 800000;
            //act

            bool actual = employeeRepo.UpdateEmployee(model);
            bool expected = true;
            //assert
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void AbilityToCheckWeatherTheDeleteEmployeeDeletedFromDB()
        {
            //Arrange
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Employee_Payroll model = new Employee_Payroll();
            model.Name = "Karthika";

            //act

            bool actual = employeeRepo.DeleteEmployee(model);
            bool expected = true;
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}