using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Dto
{
    public class CityDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<DistrictDto>? Districts {get;set;}
    }
}
