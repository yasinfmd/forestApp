using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Entity.Models
{
    public class DistrictAndCityModel
    {
        public Guid CityName { get; set; }
        public List<string> DistrictName { get; set; } = new List<string>();
    }
}
