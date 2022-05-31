using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class User : IUser
    {
        MovieDbContext _moviedbContext;

        public User(MovieDbContext moviedbContext)
        {
            _moviedbContext = moviedbContext;
        }

        public string Delete(int id)
        {
            string msg = "";
            var user = _moviedbContext.userModel.Find(id);
            if (user == null)
                return msg;
            _moviedbContext.userModel.Remove(user);
            _moviedbContext.SaveChanges();
            msg = "record deleted successfully";
            return msg;
        }

        public UserModel Login(UserModel userModel)
        {
            UserModel userData = null;
            var user = _moviedbContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count>0)
                userData = user[0];
            return userData;
            
        }

        public string Register(UserModel userModel)
        {
            string message = "";
            _moviedbContext.userModel.Add(userModel);
            _moviedbContext.SaveChanges();
            message = "Record inserted Successfully!!";
            return message;
        }

        public object SelectUser()
        {
            List<UserModel> list = _moviedbContext.userModel.ToList();
            return list;
        }

        public string Update(UserModel userModel)
        {
            string message = "";
            _moviedbContext.userModel.Update(userModel);
            _moviedbContext.SaveChanges();
            message = "Record updated Successfully!!";
            return message;
        }

        public UserModel SelectUserById(int id)
        {
            return _moviedbContext.userModel.Find(id);
        }
    }
}
