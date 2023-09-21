﻿using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMap.Controllers.View
{
    [Route("/")]
    public class HomeController : Controller
    {
        [Route("index")]
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
            var apiUrl = $"{baseUrl}/api/getlocations?path={Uri.EscapeDataString("~/Data/modifieddata.csv")}";

            List<LocationModel> locations = await FetchLocationsFromApi(apiUrl);

            return View(locations);
        }

        public async Task<List<LocationModel>> FetchLocationsFromApi(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<LocationModel>>(jsonResponse);
                }
                else
                {
                    return new List<LocationModel>();
                }
            }
        }

    }


}
