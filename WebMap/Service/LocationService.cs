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
                Quote = '"',
                HasHeaderRecord = false,
                MissingFieldFound = null,
                BadDataFound = context => {
                }

            }))
            {
                csv.Context.RegisterClassMap<LocationModelMap>();
                locations = csv.GetRecords<LocationModel>().ToList();
                foreach (var location in locations)
                {
                    if (!string.IsNullOrEmpty(location.LongitudeValue))
                    {
                        // Trim the quotes (if any) and try to parse the string to a double
                        string longitudeStr = location.LongitudeValue.Trim('"');
                        if (double.TryParse(longitudeStr, out double longitudeVal))
                        {
                            location.Longitude = longitudeVal;
                        }
                        else
                        {
                            // Handle error: could not convert to double
                        }
                    }

                    if (!string.IsNullOrEmpty(location.Station_ID_and_Site_Name))
                    {
                        var parts = location.Station_ID_and_Site_Name.Split(new[] { ';' }, 2);
                        if (parts.Length == 2)
                        {
                            location.Station_ID = parts[0].Trim('"');
                            location.Site_Name = parts[1].Trim('"');
                        }
                    }
                }

                var x = locations;
             
            }
            return locations;
        }

        private string CleanCsv(TextReader reader)
        {
            StringBuilder cleanedCsv = new StringBuilder();
            reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Replace(";\"\"", ";\"");
                line = line.Replace("\"\";", "\";");
                line = line.Replace(";;", ";\"\";");
                cleanedCsv.AppendLine(line);
            }
            return cleanedCsv.ToString();
        }

    }

    public sealed class LocationModelMap : ClassMap<LocationModel>
    {
        public LocationModelMap()
        {
            Map(m => m.Station_ID_and_Site_Name).Index(0);
            Map(m => m.Gas_Brand).Index(1);
            Map(m => m.Address).Index(2);
            Map(m => m.City).Index(3);
            Map(m => m.State).Index(4);
            Map(m => m.Zip).Index(5);
            Map(m => m.County_Name).Index(6);
            Map(m => m.Pricing_Zone).Index(7);
            Map(m => m.Cluster_Median_Price).Index(8);
            Map(m => m.Cluster_Market_Price).Index(9);
            Map(m => m.Latitude).Index(10);
            Map(m => m.LongitudeValue).Index(11);
        }
    }

}