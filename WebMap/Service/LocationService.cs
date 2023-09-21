using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using WebMap.Models;

namespace WebMap.Service
{
    public class LocationService
    {
        public List<LocationModel> FetchLocationsFromCsv(string path)
        {
            List<LocationModel> locations = new List<LocationModel>();
            using (var stream = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            using (var reader = new StringReader(CleanCsv(stream)))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                BadDataFound = null,
                MissingFieldFound = null,

            }))
            {
                locations = csv.GetRecords<LocationModel>().ToList();
                foreach(var location in locations)
                {
                    var row = location.TOTALROW;
                    string[] parts = row.Split(';');
                    location.Station_ID = parts[0];
                    location.Site_Name = parts[1].Trim('"');
                    location.Gas_Brand = parts[2];
                    location.Address = parts[3];
                    location.City = parts[4];
                    location.State = parts[5];
                    location.Zip = parts[6].Trim('"');
                    location.County_Name = parts[7];
                    location.Pricing_Zone   = parts[8].Trim('"');
                    location.Cluster_Median_Price = double.TryParse(parts[9], out double tempValMedian) ? tempValMedian : (double?)null;
                    location.Cluster_Market_Price = double.TryParse(parts[10], out double tempValMarket) ? tempValMarket : (double?)null;
                    location.Latitude = double.TryParse(parts[11], out double tempValLat) ? tempValLat : (double?)null;
                    location.Longitude = double.TryParse(parts[12], out double tempValLong) ? tempValLong : (double?)null;
                }
            }
            return locations;
        }

        //Remove header
        private string CleanCsv(TextReader reader)
        {
            StringBuilder cleanedCsv = new StringBuilder();
            reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                cleanedCsv.AppendLine(line);
            }
            return cleanedCsv.ToString();
        }
    }


}