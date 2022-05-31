using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddMovie(MovieModel movieModel)
        {
            string massage = "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            massage = "Movie Inserted Successfully..!!";
            return massage;
        }

        public string Delete(int id)
        {
            string msg = "";
            var movie=_movieDbContext.movieModel.Find(id);
            if (movie == null)
                return msg;
            _movieDbContext.movieModel.Remove(movie);
            _movieDbContext.SaveChanges();
            msg = "movie deleted successfully";
            return msg;

        }

        public MovieModel Login(MovieModel movieModel)
        {
            MovieModel movie = null;
            var user = _movieDbContext.movieModel.Where(u => u.MovieId == movieModel.MovieId && u.MovieTitle == movieModel.MovieTitle).ToList();
            if (user.Count > 0)
                movie = user[0];
            return movie;

        }


        public object SelectMovie()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;
        }

        public MovieModel SelectMovieById(int id)
        {
            return _movieDbContext.movieModel.Find(id);
        }

        public string Update(MovieModel movieModel)
        {
            string message = "";
            _movieDbContext.movieModel.Update(movieModel);
            _movieDbContext.SaveChanges();
            message = "Movie updated Successfully!!";
            return message;
        }


    }
}
