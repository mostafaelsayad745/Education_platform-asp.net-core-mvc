using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            // cookies
            //Response.Cookies.Append("Id", "1");
            //Response.Cookies.Append("Name", "Ahmed");

            //session
            HttpContext.Session.SetInt32("Id",1);
            HttpContext.Session.SetString("Name", "Ahmed");

            ViewBag.id = 1;
            ViewBag.name = "Ahmed";
            return View();
        }
        public IActionResult Display()
        {
            //int id = int.Parse(Request.Cookies["Id"]);
            //string name = Request.Cookies["Name"];

            //ViewBag.id = id;
            //ViewBag.name = name;

            int? sessionId = HttpContext.Session.GetInt32("Id");
            string SessionName = HttpContext.Session.GetString("Name");
            

            ViewBag.id = sessionId;
            ViewBag.name = SessionName;
            return View();
        }
    }
}
