using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDataApp2.Models;

namespace EFDataApp2.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult Index() =>
            View(new Dictionary<string, object>
            {
                ["Содержание"] = "Содержание"
            });

      
    }
}
