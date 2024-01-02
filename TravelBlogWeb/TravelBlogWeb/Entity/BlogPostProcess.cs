using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity
{
    public class BlogPostProcess : ICrud<BlogPost>
    {
        DataContext db = new DataContext();
        public string Add(BlogPost entity)
        {
            string result = "";
            try
            {
                var blogPost = db.BlogPosts.FirstOrDefault(x => x.Title == entity.Title);

                if (blogPost == null)
                {
                    db.BlogPosts.Add(entity);
                    db.SaveChanges();
                    result = entity.Title + " Your blog edited successfully!";
                }
                else
                {
                    result = entity.Title + " \r\nThere is already a blog with this title, try another title.";
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
            BlogPost blogPost = db.BlogPosts.FirstOrDefault(u => u.Id == id);

            if (blogPost != null)
            {
                blogPost.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public BlogPost Get(int id)
        {
            var blog = db.BlogPosts.FirstOrDefault(x => x.Id == id);
            return blog;
        }
        public List<BlogPost> GetAll()
        {
            return db.BlogPosts.ToList();
        }

        public bool Update(BlogPost entity, int id)
        {
            var editedBlog = db.BlogPosts.Find(id);
            if (editedBlog != null)
            {
                editedBlog.Title = entity.Title;
                editedBlog.Content = entity.Content;
                editedBlog.Image = entity.Image;
                editedBlog.IsDeleted = false;
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public List<BlogPost> GetCityBlogPosts(List<int> blogs)
        {
            List<BlogPost> singleCity = db.BlogPosts.Where(blog => blogs.Contains(blog.Id)).ToList();
            return singleCity;
        }

        public List<Models.BlogPost> GetTenPopulars()
        {

            var populars = db.BlogPosts
                         .OrderByDescending(blog => blog.BlogLikes.Count())
                          .Take(7)
                         .ToList();

            return populars;
        }
        public List<Models.BlogPost> GetTenLatests()
        {
            var list = db.BlogPosts
            .OrderByDescending(blog => blog.CreationDate).Take(10).ToList();
            return list;
        }

        public List<Models.BlogPost> GetMyBlogs(int userId)
        {
            List<BlogPost> userBlogs = db.BlogPosts.Where(x => x.UserId == userId).ToList();
            return userBlogs;
        }
    }
}