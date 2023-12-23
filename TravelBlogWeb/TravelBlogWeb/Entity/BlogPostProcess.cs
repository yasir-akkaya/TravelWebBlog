﻿using System;
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
            throw new NotImplementedException();
        }

        public BlogPost Get(int id)
        {
            var blog = db.BlogPosts.FirstOrDefault(x => x.Id == id );
            return blog;
        }

        public List<BlogPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogPost entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetCityBlogPosts(List<int> blogs)
        {
           
            List<BlogPost> singleCity = db.BlogPosts.Where(blog => blogs.Contains(blog.Id)).ToList();

            return singleCity;
        }
    }
}