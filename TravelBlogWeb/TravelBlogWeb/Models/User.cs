using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogWeb.Models
{
    public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public DateTime CreationDate { get; set; }

    public string Image { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BlogPost> BlogPosts { get; set; }

    public virtual ICollection<BlogLike> BlogLikes { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; }
}
}