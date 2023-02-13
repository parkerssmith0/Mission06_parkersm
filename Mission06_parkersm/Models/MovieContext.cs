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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieSubmittal>().HasData(
                new MovieSubmittal
                {
                    MovieId = 1,
                    Category = "Thriller",
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
                    Category = "Adventure",
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
                    Category = "Action",
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
