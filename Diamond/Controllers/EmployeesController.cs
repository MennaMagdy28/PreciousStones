using Microsoft.AspNetCore.Mvc;

namespace Diamond.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult GetIndexView()
        {
            return View("Index");
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
/*
 * Name: Menna Magdy Hassan Hassanien
 * University/Dep: Helwan / Software Engineering
 * Level: 4
*/
