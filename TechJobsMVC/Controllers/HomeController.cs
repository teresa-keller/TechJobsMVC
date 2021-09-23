﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TechJobsMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            ViewBag.actions = actionChoices;
            return View();
        }
    }
}
