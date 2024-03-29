﻿using Microsoft.AspNetCore.Mvc;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;
using System.Diagnostics;

namespace ResearchesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplictionDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplictionDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCityByStateId(int StateId)
        {
            var data = _context.Cities.Where(x => x.StateId == StateId).ToList();
            return Json(data);
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