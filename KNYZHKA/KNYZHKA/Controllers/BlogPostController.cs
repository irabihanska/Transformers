using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KNYZHKA.Controllers
{
    public class BlogPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
