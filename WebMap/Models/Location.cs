using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class Location
    {
        [Name("STATION_ID")]
        public int Station_ID { get; set; }

        [Name("SITENAME")]
        public string Site_Name { get; set; }

        [Name("ZDALY_GAS_BRAND")]
        public string Gas_Brand { get; set;}

        [Name("ADDRESS")]
        public string Address { get; set; }

        [Name("CITY")]
        public string City { get; set;}

        [Name("STATE")]
        public string State { get; set;}

        [Name("ZIP")]
        public int Zip { get; set;}

        [Name("COUNTY_NAME")]
        public string County_Name { get; set;}

        [Name("PRICING_ZONE")]
        public string Pricing_Zone { get; set;}

        [Name("CLUSTER_MEDIAN_PRICE")]
        public double? Cluster_Media_Price { get; set; }

        [Name("CLIENT_MARKET_PRICE")]
        public double? Cluster_Market_Price { get; set; }

        [Name("LATITUDE")]
        public double? Latitude { get; set; }

        [Name("LONGITUDE")]
        public double? Longitude { get; set; }
    }
}