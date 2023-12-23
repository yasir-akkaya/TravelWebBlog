using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity
{
    public class CommentProcess : ICrud<BlogComment>
    {
        DataContext db = new DataContext();
        public string Add(BlogComment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public List<BlogComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogComment entity, int id)
        {
            throw new NotImplementedException();
        }
        public List<BlogComment> GetBlogComments(int blogPostId)
        {
            List<BlogComment> comments = db.BlogComments.Where(comment => comment.BlogPostId == blogPostId)
                .OrderBy(comment => comment.CreationDate)
                .ToList();
            return comments;
        }

        BlogComment ICrud<BlogComment>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}