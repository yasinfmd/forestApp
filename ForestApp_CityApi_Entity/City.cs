using ForestApp_CityApi_BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Entity
{
    public class City:BaseEntity
    {
        public string Name { get; set; }

        public virtual List<District>? Districts { get; set; }
    }
}
