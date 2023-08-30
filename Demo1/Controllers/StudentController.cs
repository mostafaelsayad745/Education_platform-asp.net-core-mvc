using Demo1.Bll;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        Istudent db;
        public StudentController(Istudent _db)
        {
            db = _db;
        }
        public ViewResult Details([FromRoute] int id)
        {
            DemoDbContext dbContext = new DemoDbContext();
            Student student = dbContext.Students.FirstOrDefault(x => x.Id == id);

            return View(student);
        }
        public ViewResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                db.Add(student);
                return RedirectToAction("Index");
            }
            
            DepartmentBll bll = new DepartmentBll();
            ViewBag.departments = bll.GetAll();
            return View(student);

        }
        [HttpGet]
        public IActionResult Create()
        {
            DepartmentBll bll = new DepartmentBll();
            ViewBag.departments = bll.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) { return BadRequest(); }
            Student student = db.GetById(id.Value);
            if (student == null) { return NotFound(); }
            
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        { 
            db.Update(student);
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id)
        {
            if (id == null) { return BadRequest(); }
            db.Delete(id);
            return RedirectToAction("Index");
        }


        
        
        public IActionResult ValidateUserName(string name )
        {
            
            DemoDbContext dbContext = new DemoDbContext();
            var stdmail = dbContext.Students.Where(x => x.Name == name).FirstOrDefault();
            
            if(stdmail == null )
            {
               return Json(true);
            }
            return Json(false);


        }



    }
}
