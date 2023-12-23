using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogWeb.Models
{
    public class CityBlogRelation
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int BlogPostId { get; set; }

        public virtual City City { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}