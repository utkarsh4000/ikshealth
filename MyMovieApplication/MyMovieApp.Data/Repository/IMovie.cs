using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IMovie
    {
        string AddMovie(MovieModel movieModel);

        object SelectMovie();

        string Update(MovieModel movieModel);

        MovieModel Login(MovieModel movieModel);

        string Delete(int id);

        MovieModel SelectMovieById(int id);
    }
}
