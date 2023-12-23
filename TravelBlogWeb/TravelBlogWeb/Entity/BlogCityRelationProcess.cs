using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;
using TravelBlogWeb.Models;


namespace TravelBlogWeb.Entity
{
    public class BlogCityRelationProcess : ICrud<City>
    {
        DataContext db = new DataContext();

        public string Add(CityBlogRelation entity)
        {
            try
            {
                db.CityBlogRelations.Add(entity);
                db.SaveChanges();
                return "CityBlogRelation added successfully.";
            }
            catch (Exception ex)
            {
                return $"Error adding CityBlogRelation: {ex.Message}";
            }
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> GetCityBlogs(int id)
        {

            var blogPostIds = db.CityBlogRelations
                .Where(c => c.CityId == id)
                .Select(bc => bc.BlogPostId)
                .ToList();
            return blogPostIds;


        }

        public List<City> GetAll()
        {
            var cities = db.Cities.ToList();
            return cities;
        }

        public bool Update(City entity, int id)
        {
            throw new NotImplementedException();
        }

        City ICrud<City>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public string Add(City entity)
        {
            throw new NotImplementedException();
        }
    }
}


