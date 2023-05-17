using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;
using TestAppContext;
using TestApp.Services;
using System.Collections.Generic;
using System.Data;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> _logger;
        TestAppService objservice = new TestAppService();
        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            this.configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeDetails()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("/api/Home/SaveEmployee")]
        public List<Employee> SaveEmployee([FromBody] List<Employee> employee)
        {
            string result = "";
            List<Employee> objlist = new List<Employee>();
            using (var context = new Context(configuration))
            {
                try
                {
                    result = objservice.SaveEmployee(context, employee);
                    Employee obj = new Employee();
                    obj.Result = result;
                    objlist.Add(obj);
                }
                catch (Exception ex)
                {
                    Employee obj = new Employee();
                    obj.Result = "Failure";
                    objlist.Add(obj);
                }
            }
            return objlist;
        }
        [HttpGet]
        [Route("/api/Home/GetEmployeeDetails")]
        public ActionResult<DataTableResponse> GetEmployeeDetails()
        {
            List<Employee> employeedetails = new List<Employee>();
            using (var context = new Context(configuration))
            {
                try
                {
                    employeedetails = objservice.GetEmployeeDetails(context);
                }
                catch(Exception ex)
                {

                }
            }
            return new DataTableResponse
            {
                RecordsTotal = employeedetails.Count(),
                RecordsFiltered = 10,
                Data = employeedetails.ToArray()
            };
        }
    }
}