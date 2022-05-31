using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IUser
    {
        string Register(UserModel userModel);

        string Update(UserModel userModel);

        UserModel Login(UserModel userModels);

        string Delete(int id);

        object SelectUser();

        UserModel SelectUserById(int id);
    }
}
