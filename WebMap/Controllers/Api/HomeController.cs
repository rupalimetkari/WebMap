using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebMap.Models;
using WebMap.Service;

namespace WebMap.Controllers.Api
{
  
    public class HomeController : ApiController
    {
        [Route("api/getlocations")]
        public IHttpActionResult GetLocations(string path)
        {
            LocationService service = new LocationService();
            var locations = service.GetLocationsFromCsv(path);
            return Ok(locations);
        }


    }
}
