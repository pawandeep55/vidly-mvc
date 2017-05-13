using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMvc.Models;
using System.Data.Entity;
using VidlyMvc.ViewModels;
namespace VidlyMvc.Controllers
{

    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();//this context is a disposable context so we need to properly dispose via Dispose()
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);


        }

        public ActionResult New()
        {
            var Genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = Genre,
               // Movie=new Movie()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //this will be called after submitting new or existing record//new or edit action submit
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                   // Movie = movie,
                    Genre = _context.Genre.ToList()
                };
            return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        //called for editing existing records
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                //Movie = movie,
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Delete(int id)
        {

            return View();
        }

        /*public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }*/

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            /*var lin = (from mov in movies
                       where mov.Id == id
                       select mov);
            var v = lin.SingleOrDefault();*/
            if (movie == null) { return HttpNotFound(); }
            return View(movie);
        }
        /*public IEnumerable<Movie> getMovies()
        {
            return new List<Movie>
            {
            new Movie{ Id = 1, Name = "bang bang" },
            new Movie{ Id = 2, Name = "fast and furious 8" },
            };
            // return new List<Movie>() ;
        }*/
    }
}