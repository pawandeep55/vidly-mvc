using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMvc.Models;

namespace VidlyMvc.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}