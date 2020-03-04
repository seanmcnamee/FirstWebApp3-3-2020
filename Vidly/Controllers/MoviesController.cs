using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public static List<Movie> movieList = new List<Movie> () 
        { 
            new Movie() { Name = "Jurassic Park", Id = 1993 },
            new Movie() { Name = "Shrek", Id = 2001}
        };

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = movieList[new Random().Next(0, movieList.Count)];
            var customers = new List<Customer>
            {
                new Customer { Name = "Sean", Id = 1270817 },
                new Customer { Name = "Your Mom", Id = 9999999 }
            };

            var viewModel = new RandomMovieViewModel 
            { 
                Movie = movie, 
                Customers = customers 
            };
            //Requires Redundancy //ViewData["Movie"] = movie;
            //Same problem // ViewBag.Movie = movie //On-Runtime property
            
            return View(viewModel);
            //return Content("Sup MF");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            var viewModel = new MovieListViewModel() { Movies = movieList };
            return View(viewModel);
        }
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //"pageIndex=" + pageIndex + ", sortBy=" + sortBy
            return Content(String.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy));
        }
        */

        //ASP.NET MVC Attribute Route Contraints
        [Route("movies/released/{year:max(2020)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}