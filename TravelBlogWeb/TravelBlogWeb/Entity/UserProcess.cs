using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity
{
    public class UserProcess : ICrud<User>
    {
        DataContext db= new DataContext();
        public string Add(User entity)
        {
            string result = "";
            var user = db.Users.FirstOrDefault(x => x.Email == entity.Email);
            if (user == null &&
                !String.IsNullOrWhiteSpace(entity.Name) &&
                !String.IsNullOrWhiteSpace(entity.Email) &&
                !String.IsNullOrWhiteSpace(entity.Password))
            {
                db.Users.Add(entity);
                db.SaveChanges();
                result = entity.Email + " Kullanıcı Ekleme Başarılı";
            }
            else
            {
                result = entity.Email + " Email Adresi Daha Önce Kayıt Olmuş. Başka Email İle Devam Ediniz.";
            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}