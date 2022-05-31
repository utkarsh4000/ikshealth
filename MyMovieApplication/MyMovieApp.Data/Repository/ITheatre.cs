using System;
using System.Collections.Generic;
using System.Text;
using MyMovieApp.Entity;
namespace MyMovieApp.Data.Repository
{
    public interface ITheatre
    {
        TheatreModel SearchTheatre(TheatreModel theatreModel);

        object AllTheatre();

        public string InsrtData(TheatreModel theatreModel);

        string Update(TheatreModel theatreModel);

        TheatreModel Login(TheatreModel theatreModel);

        string Delete(int id);

        TheatreModel SelectTheatreById(int id);
    }
}
