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
                return true;
            }
            return false;
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
        }
        public List<User> GetAll()
        {
            return db.Users.Where(u => !u.IsDeleted).ToList();
        }

        public bool Update(User entity, int id)
        {
            User userToUpdate = db.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);

            if (userToUpdate != null)
            {
                userToUpdate.Name = entity.Name;
                userToUpdate.Email = entity.Email;
                userToUpdate.Password = entity.Password;
                userToUpdate.Image = entity.Image;
                userToUpdate.IsAdmin = entity.IsAdmin;
                userToUpdate.IsDeleted = entity.IsDeleted;
                return true;
            }

            return false;
        }
    }
}