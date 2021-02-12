using System;
using System.ComponentModel.DataAnnotations;

namespace ForestApp_CityApi_BaseEntity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedOn { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}
