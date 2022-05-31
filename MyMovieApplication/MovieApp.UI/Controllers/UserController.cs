using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyMovieApp.Entity;
using System.Text;
using Newtonsoft.Json;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        public IConfiguration _configuration;

        public UserController(IConfiguration iconfiguration)
        {
            _configuration = iconfiguration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> ShowUserDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);

                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }

                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registered";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration failed...!";
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> EditUser(int userId)
        {
            string endpoint = _configuration["WebApiURL"] + "User/SelectUserById?id="+userId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var user = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(user);
                    }
                   

                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "User/Update";
            using (HttpClient client = new HttpClient())
            {
                
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Updated";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Registration failed...!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteUser(int UserId)
        {
            string endpoint = _configuration["WebApiURL"] + "User/SelectUserById?id="+UserId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var user = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(user);
                    }


                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserModel userModel)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "User/Delete";
            using (HttpClient client = new HttpClient())
            {
                
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deleted";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Deletion failed...!";
                    }
                }
            }
            return View();
        }

    }
}
