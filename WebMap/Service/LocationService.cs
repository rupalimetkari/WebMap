using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using WebMap.Models;

namespace WebMap.Service
{
    public class LocationService
    {
        public List<LocationModel> GetLocationsFromCsv(string path)
        {
            List<LocationModel> locations = new List<LocationModel>();

            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                locations = csv.GetRecords<LocationModel>().ToList();
            }

            return locations;
        }
    }

}