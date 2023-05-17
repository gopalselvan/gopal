using TestApp.DataModels;
using TestApp.Models;
using TestAppContext;
namespace TestApp.Services
{
    public class TestAppService
    {
        public string SaveEmployee(Context context, List<Employee> employee)
        {
            string result = "";
            var employeeclass = new EmployeeModel();
            try
            {
                employeeclass.employeename = employee[0].EmployeeName;
                employeeclass.fathername = employee[0].FatherName;
                employeeclass.dob = DateTime.Parse(employee[0].DOB);
                employeeclass.employeedesignation = Convert.ToChar(employee[0].EmployeeDesignation);
                employeeclass.gender = employee[0].Gender;
                employeeclass.skill1 = employee[0].Skill1;
                employeeclass.skill2 = employee[0].Skill2;
                employeeclass.skill3 = employee[0].Skill3;
                employeeclass.skill4 = employee[0].Skill4;
                employeeclass.skill5 = employee[0].Skill5;
                context.Add(employeeclass);
                context.SaveChanges();
                result = "Success";
            }
            catch(Exception ex)
            {
                result = "Failure";
            }
            return result;
        }
        public List<Employee> GetEmployeeDetails(Context context)
        {
            List<Employee> employeedetails = new List<Employee>(); //Multiple data
            try
            {
                employeedetails = (from A in context.employees 
                                   select new Employee
                                   {
                                      EmployeeId=A.employeeid,
                                      EmployeeName=A.employeename,
                                      FatherName=A.fathername,
                                      DOB=Convert.ToDateTime(A.dob).ToString("dd-MM-yyyy"), //Format change dd-MM-yyyy
                                      EmployeeDesignation=Convert.ToString(A.employeedesignation),
                                      Gender=A.gender,
                                      Skill1=A.skill1,
                                      Skill2=A.skill2,
                                      Skill3=A.skill3,
                                      Skill4 = A.skill4,
                                      Skill5 = A.skill5,
                                   }).ToList();
            }
            catch(Exception ex)
            {

            }
            return employeedetails;
        }
    }
}
