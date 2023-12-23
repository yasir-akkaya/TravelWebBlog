using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogWeb.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        public virtual ICollection<CityBlogRelation> CityBlogRelations { get; set; }
    }
}