using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMvc.Models;
using System.Data.Entity;

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

        /*public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }*/

        public ActionResult Details(int id)
        {

            var movie =_context.Movies.Include(m=>m.Genre).SingleOrDefault(m=>m.Id==id);

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