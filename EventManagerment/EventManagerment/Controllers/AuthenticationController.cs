using EventManagerment.DBContext;
using EventManagerment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EventManagerment.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public AuthenticationController(AppDBContext context, IHttpContextAccessor? httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string? userName, string? passWord)
        {
            User? user = _context.Users.FirstOrDefault(a => a.Username == userName && a.Password == passWord);
            if (user == null)
            {
                ViewBag.Message = "User Name or Password is Wrong!!";
                return View("index", "Authentication");
            }
            _httpContextAccessor.HttpContext.Session.SetString("UserId-Session", user.UserID.ToString());
            _httpContextAccessor.HttpContext.Session.SetString("UserName-Session", user.Username.ToString());
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}