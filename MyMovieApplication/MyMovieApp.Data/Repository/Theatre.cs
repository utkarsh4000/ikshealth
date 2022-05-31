using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;

namespace MyMovieApp.Data.Repository
{
    public class Theatre : ITheatre
    {
        MovieDbContext _moviedbContext;

        public Theatre(MovieDbContext moviedbContext)
        {
            _moviedbContext = moviedbContext;
        }

        public object AllTheatre()
        {
            List<TheatreModel> list = _moviedbContext.TheatreModel.ToList();
           // if (thetreModel1.Count > 0)
                return list;
           // else
              //  return null;
                      
        }

        public TheatreModel SearchTheatre(TheatreModel thetreModel)
        {
            var m = _moviedbContext.TheatreModel.Where(m => m.TheatreId == thetreModel.TheatreId && m.movie == thetreModel.movie).ToList();
            if (m.Count > 0)
                return m[0];
            else
                return null;
        }

        public string InsrtData(TheatreModel thetreModel)
        {
            string msg = "";
            _moviedbContext.TheatreModel.Add(thetreModel);
            _moviedbContext.SaveChanges();
            msg = "data added successfully";
            return msg;
        }
     
        public string Delete(int id)
        {
            string msg = "";
            var user = _moviedbContext.TheatreModel.Find(id);
            if (user == null)
                return msg;
            _moviedbContext.TheatreModel.Remove(user);
            _moviedbContext.SaveChanges();
            msg = "record deleted successfully";
            return msg;
        }

        public TheatreModel Login(TheatreModel theatreModel)
        {
            TheatreModel userData = null;
            var user = _moviedbContext.TheatreModel.Where(u => u.TheatreId == theatreModel.TheatreId && u.Location == theatreModel.Location).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;

        }      

        public string Update(TheatreModel theatreModel)
        {
            string message = "";
            _moviedbContext.TheatreModel.Update(theatreModel);
            _moviedbContext.SaveChanges();
            message = "Record updated Successfully!!";
            return message;
        }

        public TheatreModel SelectTheatreById(int id)
        {
            return _moviedbContext.TheatreModel.Find(id);
        }
    }
}
