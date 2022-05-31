using Microsoft.EntityFrameworkCore;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.DataConnection
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }

        public DbSet<UserModel> userModel { get; set; }
        public DbSet<MovieModel> movieModel { get; set; }
        public DbSet<TheatreModel> TheatreModel { get; set; }

    }
}
