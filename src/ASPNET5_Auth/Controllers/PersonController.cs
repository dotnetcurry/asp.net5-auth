using Microsoft.AspNet.Mvc;

using ASPNET5_Auth.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET5_Auth.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var persons = new PersonDatabase();
            return View(persons);
        }
    }
}
