using MyMovieApp.Data.DataConnection;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class MovieService
    {
        IMovie movie;

        public MovieService(IMovie movie)
        {
            this.movie = movie;
        }

        public string AddMovie(MovieModel movieModel)
        {
            return movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return movie.SelectMovie();
        }

        public string Update(MovieModel movieModel)
        {
            return movie.Update(movieModel);
        }

        public string Delete(int id)
        {
            return movie.Delete(id);
        }

        public object Login(MovieModel movieModel)
        {
            return movie.Login(movieModel);
        }

        public MovieModel SelectMovieById(int id)
        {
            return movie.SelectMovieById(id);
        }
    }
}
