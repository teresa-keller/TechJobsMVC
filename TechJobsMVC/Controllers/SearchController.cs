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
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            //ViewBag.tableChoices = ListController.TableChoices;
            return View();
        }

        [HttpPost]
        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.tableChoices = ListController.TableChoices;
            List<Job> jobs = new List<Job>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
            }
            else 
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.Title = "Jobs";
            ViewBag.jobs = jobs;
            
            return View("Index");
        }
       
        /*public IActionResult Results(string searchType, string searchTerm = "all")
        {
            List<Job> jobs = new List<Job>();
            if (searchTerm.ToLower().Equals("all"))
            {
                jobs = JobData.FindAll();
                
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ColumnChoices[searchType] + ": " + searchTerm;
            }
            ViewBag.jobs = jobs;

            return View();
        }*/
    }
}