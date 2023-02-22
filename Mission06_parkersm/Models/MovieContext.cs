using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_parkersm.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<MovieSubmittal> movieSubmittals { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Thriller"},
                new Category { CategoryId=2, CategoryName="Adventure"},
                new Category { CategoryId=3, CategoryName="Action"},
                new Category { CategoryId=4, CategoryName="Romance"},
                new Category { CategoryId=5, CategoryName="Comedy"}
                );

            mb.Entity<MovieSubmittal>().HasData(
                new MovieSubmittal
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Split",
                    Year = "2016",
                    Director = "M. Night Shyamalan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieSubmittal
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "The Secret Life of Walter Mitty",
                    Year = "2013",
                    Director = "Ben Stiller",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieSubmittal
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "The Avengers",
                    Year = "2012",
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
