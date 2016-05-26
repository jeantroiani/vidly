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
            var movie = new Movie() { Name = "Frozen" };
            return View(movie);
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
        
    }
}