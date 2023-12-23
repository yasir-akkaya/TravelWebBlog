using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;

namespace TravelBlogWeb.Entity
{
    public class PartialProcess : ICrud<PartialProcess>
    {
        DataContext db = new DataContext();

        public string Add(PartialProcess entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PartialProcess Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PartialProcess> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(PartialProcess entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.BlogPost> GetPopulars()
        {

            var populars = db.BlogPosts
                         .OrderByDescending(blog => blog.BlogLikes.Count())
                          .Take(3) 
                         .ToList();

            return populars;
        }

        public List<Models.BlogPost> GetLatests()
        {
            var list = db.BlogPosts
            .OrderByDescending(blog => blog.CreationDate).Take(3).ToList();
            return list;
        }


    }
}