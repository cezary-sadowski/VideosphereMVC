using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videosphere.Models;
using Videosphere.ViewModels;

namespace Videosphere.Controllers
{
    public class MoviesController : Controller 
    {
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Matrix" },
                new Movie { Id = 2, Name = "Ghost in the shell" }
            };
        }

        // GET: Movies/Random
        
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Matrix" };

            //return RedirectToAction("Index", "Home", new { page = 1, SortBy = "name" });
            //anonimowy obiekt jako 3 parametr.

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }




        //Route nizej moge uzywac bo w RouteConfig.cs jest routes.MapMvcAttributeRoutes();
        /*
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month) //w sumie dla month moglbym byte.
        {
            return Content(year + "/" + month);
        }
        */


        /*
        public ActionResult Edit(int id) // movies/edit/5  <- przekazuje parametr w url.
        {
            return Content("id=" + id);
        }

        // movies (this action will be called when we navigate to movies).
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        */

        // if page index is not specified, display the movies in page 1.
        // if sortBy is not specified, sort movies by their names.
        // to make parameters optional, make it nullable.
        // ? za int robi go nullable. string jest reference type wiec jest nullable.
    }
}


/* ACTION - a method in a controller for handling a request.
 * 
 * w zaleznosci od akcji zawsze returnuje instancje klas, ktore po niej dziedzicza.
 * View() pomocnicza metoda dziedziczona po 'Controller'.
 * zamiast View(param) moge: return new ViewResult(param);
 * 
 * wszystkie z bazowej Controller:
 * 
 * 
 * [TYPE]                   [HELPER METHOD]
 * ViewResult               View()
 * PartialViewResult        PartialView()
 * ContentResult            Content()
 * RedirectResult           Redirect()
 * RedirectToRouteResult    RedirectToAction()
 * JsonResult               Json()
 * FileResult               File()
 * HttpNotFoundResult       HttpNotFound()
 * EmptyResult
 */
