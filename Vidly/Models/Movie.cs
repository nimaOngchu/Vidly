using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public Movie() {
            this.DateAddedToDB = System.DateTime.Now;
        }
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter The name of the movie")]
        public string Name { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime DateAddedToDB { get; set; }

        [Required(ErrorMessage = "Please enter the number of stock")]
        public int StockNumber { get; set; }

       
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int  GenreId { get; set; }

    }
    //movie//random
}