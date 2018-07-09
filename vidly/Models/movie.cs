using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(50)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        [Display (Name = "Release Date")]
        [Required]
        public DateTime ReleaseDateTime { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name="Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }

    }
}