using System;
using Microsoft.EntityFrameworkCore;

namespace Webapplication2.Models
{
    public class Context : DbContext
    {
        //constructor
      public Context (DbContextOptions<Context> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<MovieFormModel> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Thriller"},
                new Category { CategoryID=2, CategoryName="Family"},
                new Category { CategoryID=3, CategoryName = "Drama" }
                );

            mb.Entity<MovieFormModel>().HasData(
                // seed 3 movies into database
                new MovieFormModel
                {
                        MovieID = 1,
                        CategoryID = 1,
                        Title = "Vertigo",
                        Year = 1958,
                        Director = "Alfred Hitchcock",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "Aidan",
                        Notes = "Good movie."
                },
                new MovieFormModel
                {
                        MovieID = 2,
                        CategoryID = 2,
                        Title = "WALL-E",
                        Year = 2008,
                        Director = "Andrew Stanton",
                        Rating = "G",
                        Edited = false,
                        LentTo = "Aidan",
                        Notes = "Good movie."

                },
                new MovieFormModel
                {
                        MovieID = 3,
                        CategoryID = 3,
                        Title = "Shawshank Redemption",
                        Year = 1994,
                        Director = "Frank Darabont",
                        Rating = "R",
                        Edited = false,
                        LentTo = "Aidan",
                        Notes = "Good movie."
                }
            );
        }
    }
}
