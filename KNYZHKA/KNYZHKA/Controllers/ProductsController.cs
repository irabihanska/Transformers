using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KNYZHKA.Controllers
{
    public class ProductsController : Controller
    {

       
        public string Welcome()
        {
            return "Welcome to My Cricketer Controller";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
