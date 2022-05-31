using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController: Controller
    {
        public IConfiguration _configuration;

        public MovieController(IConfiguration iconfiguration)
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

        public async Task<IActionResult> ShowMovieDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        return View(movieModel);

                    }
                    /*else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }*/

                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Movie/AddMovie";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
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


        public async Task<IActionResult> EditMovie(int movieId)
        {
            string endpoint = _configuration["WebApiURL"] + "Movie/SelectMovieById?id="+movieId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var movie = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movie);
                    }
                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> EditMovie(MovieModel movieModel)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Movie/Update";
            using (HttpClient client = new HttpClient())
            {

                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "updation failed...!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            string endpoint = _configuration["WebApiURL"] + "User/SelectUserById?id="+movieId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var movie = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movie);
                    }


                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(MovieModel movieModel)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Movie/Delete";
            using (HttpClient client = new HttpClient())
            {

                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
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
