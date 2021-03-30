using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibroSwap.Controllers
{
    public class Product_DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
