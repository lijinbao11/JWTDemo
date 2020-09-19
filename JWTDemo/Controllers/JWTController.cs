using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    public class JWTController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
