﻿using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrganizersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}