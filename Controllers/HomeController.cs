using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Paging.Services;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        private readonly IColorService _colorService;

        public HomeController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IActionResult Index(int PageId=1 , int take=2 , string filter="")
        {
            var Colores = _colorService.GetColorForAdmin(PageId, take, filter);

            return View(Colores);
        }

        [HttpPost]
        public IActionResult Search(int PageId,int take,string filter)
        {
            var Colores = _colorService.GetColorForAdmin(PageId, take, filter);
            return PartialView("_Colores", Colores);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
