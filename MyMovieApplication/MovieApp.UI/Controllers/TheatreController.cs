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
    public class TheatreController : Controller
    {
        public IConfiguration _configuration;

        public TheatreController(IConfiguration iconfiguration)
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

        public async Task<IActionResult> ShowTheatreDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theatre/SearchTheatre";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                        return View(theatreModel);

                    }
                   /* else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }*/

                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Theatre/InsertData";
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


        public async Task<IActionResult> EditTheatre(int theatreId)
        {
            string endpoint = _configuration["WebApiURL"] + "Theatre/SelectTheatreById?id=" + theatreId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var theatre = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatre);
                    }


                }
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> EditTheatre(TheatreModel theatreModel)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Theatre/Update";
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
                        ViewBag.message = "Registration failed...!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteTheatre(int theatreId)
        {
            string endpoint = _configuration["WebApiURL"] + "User/SelectUserById?id=" + theatreId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel 
                        var theatre = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatre);
                    }


                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTheatre(TheatreModel theatreModel)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Theatre/Delete";
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
