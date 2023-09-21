using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            List<Location> locations = new List<Location>();

            using (var reader = new StreamReader(Server.MapPath("~/Data/modifieddata.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                locations = csv.GetRecords<Location>().ToList();
                var x = 5;
            }

            return View();
        }
    }


    public class Location
    {
        [Name("LATITUDE")]
        public double? Latitude { get; set; }

        [Name("LONGITUDE")]
        public double? Longitude { get; set; }
    }
}
