using System;
using System.ComponentModel.DataAnnotations;

namespace Webapplication2.Models
{
    //create model
    public class MovieFormModel
    {
        //make a primary key
        // category, title, year director, and rating are all required fields.
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
      
        public bool Edited { get; set; }
       
        public string LentTo { get; set; }
        //notes have a 25 character max length.
        [MaxLength(25)]
        public string Notes { get; set; }

        // build foreign key relationship.
       
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
