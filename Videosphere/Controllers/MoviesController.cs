using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videosphere.Models;
using Videosphere.ViewModels;
using Videosphere.Migrations;
using System.Data.Entity.Validation;

namespace Videosphere.Controllers
{
    public class MoviesController : Controller 
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //dobrze rozpisane na stackov. convention.
        {
            base.Dispose(disposing);
        }

        public ViewResult Index() //ViewResult bo konkretnie zwracam tylko View a nie zaleznie od sytuacji.
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id) //ActionResult bo to base klas i moge zwrocic 404error lub view.
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id); // ==id bo param.

            if (movie == null)
                return HttpNotFound();

            return View(movie);
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

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.AddDate = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            

            return RedirectToAction("Index", "Movies");
        }




        //Route nizej moge uzywac bo w RouteConfig.cs mam routes.MapMvcAttributeRoutes();
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
        // string jest reference type wiec jest nullable.
    }
}


/* ACTION - a method in a controller for handling a request.
 * 
 * w zaleznosci od akcji zawsze zwraca instancje klas, ktore po niej dziedzicza.
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
