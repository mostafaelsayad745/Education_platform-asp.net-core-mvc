using Demo1.Bll;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBll db = new DepartmentBll();
        public ViewResult Detials([FromRoute]int id)
        {
            DemoDbContext dbc = new DemoDbContext();
            Department department = dbc.Departments.FirstOrDefault(d => d.Id == id);
            return View(department);
        }
        public ViewResult Index()
        {
            var model = db.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Add(department);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) { return BadRequest(); }
            Department department = db.GetById(id.Value);
            if (department == null) { return NotFound(); }
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Update(department);
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            if (id == null) { return BadRequest(); }
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
