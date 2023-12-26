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
            string result = "";
            try
            {
                var comment = db.BlogComments.FirstOrDefault(x => x.Comment == entity.Comment);

                if (comment == null)
                {
                    db.BlogComments.Add(entity);

                    db.SaveChanges();
                    result = entity.Comment + " Comment Added Successfully";
                }
                else
                {
                    result = entity.Comment + " Comment can't added!";
                }
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }

            return result;
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
            List<BlogComment> comments = db.BlogComments.Where(comment => comment.BlogPostId == blogPostId && comment.IsActive==true)
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