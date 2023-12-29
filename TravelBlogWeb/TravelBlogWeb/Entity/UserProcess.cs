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
            User userToDelete = db.Users.FirstOrDefault(u => u.Id == id);

            if (userToDelete != null)
            {
                userToDelete.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public User Get(string mail)
        {
              User user= db.Users.FirstOrDefault(u => u.Email == mail);
            return user;
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public bool Update(User entity, int id)
        {
            User userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate != null)
            {
                userToUpdate.Name = entity.Name;
                userToUpdate.Email = entity.Email;
                userToUpdate.Password = entity.Password;
                userToUpdate.Image = entity.Image;
                userToUpdate.IsDeleted = entity.IsDeleted;
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}