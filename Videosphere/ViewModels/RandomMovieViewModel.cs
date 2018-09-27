using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videosphere.Models;


namespace Videosphere.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}

//w ViewModels tworze klase, ktora korzysta klas z Models (Customer i Movie).
//np kazdy Customer w liscie Customers ma property z klasy Customer logiczne.