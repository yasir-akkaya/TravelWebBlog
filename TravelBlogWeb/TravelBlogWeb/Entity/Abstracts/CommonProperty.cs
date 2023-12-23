using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogWeb.Entity.Abstracts
{
    public abstract class CommonProperty
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}