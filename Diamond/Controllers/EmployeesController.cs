using Diamond.Data;
using Diamond.Models;
using Microsoft.AspNetCore.Mvc;

//Shahd Ashraf Abu El enein Hassan
//Field of Study: Computer Science
//Major:Software Engineering
//Uni: Helwan University
//Level: 4


namespace Diamond.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet]
        public IActionResult GetIndexView(string? search)
        {
            ViewBag.SearchValue = search;
            if (string.IsNullOrEmpty(search) == false)
            {
                return View("Index", context.Employees.Where(e=>e.FullName.Contains(search) ||
                e.Position.Contains(search)).ToList());
            }
            else {
                return View("Index", context.Employees.ToList());
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(context.Employees.ToList());
        }
        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null) return NotFound();

            return View("Details", employee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null) return NotFound();

            return View(employee);
        }
        [HttpGet]
        public IActionResult GetCreateView()
        {
            return View("Create");
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(Employee employee)
        {
            if (employee.BirthDate.AddYears(18) > DateTime.Now)
            {
                ModelState.AddModelError(nameof(employee.BirthDate), "Illegal Hiring Age (Under 18 years old).");
            }
            if (ModelState.IsValid == true)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            return View("Create", employee);
        }
        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View("Delete", employee);
        }

        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction(nameof(GetIndexView));
        }
        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View("Edit", employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult EditCurrent(Employee employee)
        {
            if (employee.BirthDate.AddYears(18) > DateTime.Now)
            {
                ModelState.AddModelError(nameof(employee.BirthDate), "Illegal Hiring Age (Under 18 years old).");
            }
            if (ModelState.IsValid == true)
            {
                context.Employees.Update(employee);
                context.SaveChanges();
                return RedirectToAction(nameof(GetIndexView));
            }
            return View("Edit", employee);
        }
    }
 
}
