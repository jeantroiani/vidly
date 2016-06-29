using System;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Frozen" };
            return View(movie);
        }

        public ActionResult ShowMovieData()
        {
            object movie = new Movie { Name = "Conan"};
            //how to use View Data
            ViewData["Movie"] = movie;
            // how to use view bag
            ViewBag.AnotherDisneyHit = "Beauty and the Beast";
            return View();
        }

        //Action parameters
        //Movies/Edit/Id  or   Movies/Edit?Id=7
        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (sortBy.IsNullOrWhiteSpace())
            {
                sortBy = "Name";
            }
            return Content($"page index: {pageIndex}, and sort by {sortBy}");
        }

        //Movies/Content?pageIndex=3&sortBy=Name
        public ActionResult Content(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;

            }
            if (!sortBy.IsNullOrWhiteSpace())
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageIndex{0}, and sort by {1}", pageIndex, sortBy));


        }

        public ActionResult Redirect()
        {
            return RedirectToAction("Index",new {pag= 12} );
        }

        // new routes created with a different structure than default.
        public ActionResult ByReleaseDate(int? year, int month)
        {
            return Content($" looking for a movie released on {year} on the month of {month}");
        }

        [Route("movies/wishlist/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByWishListed(int? year, int month)
        {
            return Content($"The list of wishlisted movies added on this month {month} of this year {year}");
        }

    }
}