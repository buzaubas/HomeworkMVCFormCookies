//using HomeworkMVCFormCookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace HomeworkMVCFormCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger /*ApplicationDbContext dbContext*/)
        {
            _logger = logger;
            //this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value, DateTime currentdate)
        {
            //HttpCookie myCookie = new HttpCookie("MyTestCookie");
            //DateTime now = DateTime.Now;

            //// Set the cookie value.
            //myCookie.Value = now.ToString();
            //// Set the cookie expiration date.
            //myCookie.Expires = now.AddMinutes(1);

            //// Add the cookie.
            //Response.Cookies.Add(myCookie);

            ViewBag.Message = "Success";

            //var myCookie = HttpContext.Request.Cookies["cookieName"];

            //if (myCookie == null)
            //{
            //    ViewBag.Debug = "Cookie not found";
            //}

            //Cookie cookie = new Cookie();
            //cookie.Id = "value";
            //cookie.Value = value;
            //cookie.ExpireDate = currentdate;

            //dbContext.Cookies.Add(cookie);
            //dbContext.SaveChanges();

            //Cookie cookie = new Cookie("value", value);
            //cookie.Expires = currentdate;

            CookieOptions option = new CookieOptions();
            option.Expires = currentdate;

            HttpContext.Response.Cookies.Append("value", value, option);

            //HttpContext.Response.Cookies.Append("value", value, CookieOptions.Equals());

            //HttpContext.Response.Cookies.Append("value", value);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("[controller]/CheckCookies/{name}")]
        public IActionResult CheckCookies(string name)
        {
            if (HttpContext.Request.Cookies.ContainsKey(name))
            {
                ViewBag.Value = HttpContext.Request.Cookies[name];
            }
            else
            {
                ViewBag.Value = "Cookie Not Found";
            }
            

            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}