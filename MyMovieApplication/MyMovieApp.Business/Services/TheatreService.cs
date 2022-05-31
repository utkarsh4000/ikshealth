using System;
using System.Collections.Generic;
using System.Text;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;

namespace MyMovieApp.Business.Services
{
    public class TheatreService
    {
        ITheatre itheatre;

        public TheatreService(ITheatre _theatre)
        {
            itheatre = _theatre;
        }

        public object AllTheatre()
        {
            return itheatre.AllTheatre();
        }

        public TheatreModel SearchTheatre(TheatreModel theatreModel)
        {
            return itheatre.SearchTheatre(theatreModel);
        }

        public string InsertData(TheatreModel theatreModel)
        {
            return itheatre.InsrtData(theatreModel);
        }

        public string Update(TheatreModel theatreModel)
        {
            return itheatre.Update(theatreModel);
        }

        public string Delete(int id)
        {
            return itheatre.Delete(id);
        }

        public object Login(TheatreModel theatreModel)
        {
            return itheatre.Login(theatreModel);
        }

        public TheatreModel SelectTheatreById(int id)
        {
            return itheatre.SelectTheatreById(id);
        }
    }
}
