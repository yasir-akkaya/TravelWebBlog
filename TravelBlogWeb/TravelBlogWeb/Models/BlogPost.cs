using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogWeb.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<BlogLike> BlogLikes { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }

        public virtual ICollection<CityBlogRelation> CityBlogRelations { get; set; }
    }
}