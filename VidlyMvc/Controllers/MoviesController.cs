﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMvc.Models;

namespace VidlyMvc.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {

            var movies = getMovies();

            return View(movies);


        }

        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }

        public ActionResult Details(int id)
        {

            var movies = getMovies();

            var lin = (from mov in movies
                       where mov.Id == id
                       select mov);
            var v = lin.SingleOrDefault();
            if (v == null) { return HttpNotFound(); }
            return Content("id u entered is " + id + "name is " + v.Name);
        }
        public IEnumerable<Movie> getMovies()
        {
            return new List<Movie>
            {
            new Movie{ Id = 1, Name = "bang bang" },
            new Movie{ Id = 2, Name = "fast and furious 8" },
            };
            // return new List<Movie>() ;
        }
    }
}