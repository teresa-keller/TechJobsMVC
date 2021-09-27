using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"employer", "Employer"},
            {"location", "Location"},
            {"positionType", "Position Type"},
            {"coreCompetency", "Skill"}
        };
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs = new List<Job>();
            try
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm = "all");
            }
            catch (NullReferenceException e)
            {
                if (e.Source.Equals("null"))
                {
                    jobs = JobData.FindAll();

                }
            }

            ViewBag.jobs = jobs;
            
            return View();
        }
    }
}