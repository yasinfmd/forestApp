using ForestApp_CityApi_BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Entity
{
    public class District:BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }

        public virtual City? City { get; set; }

    }
}
