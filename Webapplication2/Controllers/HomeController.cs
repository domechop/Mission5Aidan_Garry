using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webapplication2.Models;

namespace Webapplication2.Controllers
{
    public class HomeController : Controller
    {

        private Context moContext { get; set; }

        //Constructor
        public HomeController(Context x)
        {
          
            moContext = x;
        }

        public IActionResult Index()
        { 
            return View();
        }
        // Have Get and Post to be able to save to database
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = moContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieFormModel ar)
        {
            // add if statement to see if all model requirements are satisfied
            if (ModelState.IsValid){
                moContext.Add(ar);
                moContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //if invalid
            {
                ViewBag.Categories = moContext.Categories.ToList();
                return View();
            }
        }
        // return MyPodcasts view page

        public IActionResult MyPodcasts()
        {
            return View();
        }
        //list all the movies in movie table
        public IActionResult MovieTable()
        {
            var movies = moContext.Responses
                .Include(x => x.Category)
                .ToList();
       
            return View(movies);
        }
       //send user back to movieform if they want to edit
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = moContext.Categories.ToList();

            var movies = moContext.Responses.Single(x => x.MovieID == movieid);
            //connect id to bring the info back
            return View("MovieForm", movies);
        }

        [HttpPost]
        public IActionResult Edit(MovieFormModel bob)
        {
            if (ModelState.IsValid)
            {
                moContext.Update(bob);
                moContext.SaveChanges();
                return RedirectToAction("MovieTable");
            }
            else
            {
                ViewBag.Categories = moContext.Categories.ToList();
                return View("MovieForm");
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movies = moContext.Responses.Single(x => x.MovieID == movieid);
            return View(movies);
        }
        [HttpPost]
        public IActionResult Delete(MovieFormModel mf)
        {
            moContext.Responses.Remove(mf);
            moContext.SaveChanges();

            return RedirectToAction("MovieTable");

            
        }
     
    }
}
