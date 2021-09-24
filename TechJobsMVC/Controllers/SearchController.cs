using Microsoft.AspNetCore.Mvc;
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
        internal static Dictionary<string, List<JobField>> TableChoices = new Dictionary<string, List<JobField>>()
        {
            {"employer", JobData.GetAllEmployers()},
            {"location", JobData.GetAllLocations()},
            {"positionType", JobData.GetAllPositionTypes()},
            {"coreCompetency", JobData.GetAllCoreCompetencies()}
        };
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs;
            ViewBag.columns = ColumnChoices;
            ViewBag.tableChoices = TableChoices;
            ViewBag.employers = JobData.GetAllEmployers();
            ViewBag.locations = JobData.GetAllLocations();
            ViewBag.positionTypes = JobData.GetAllPositionTypes();
            ViewBag.skills = JobData.GetAllCoreCompetencies();
            jobs = JobData.FindAll();
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            
            List<Job> jobs;
            if (searchTerm == null)
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All jobs";
                
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ViewBag.columns[searchType] + ": " + searchTerm;
            }
            ViewBag.jobs = jobs;

            return View("Index");
        }

    }
}
