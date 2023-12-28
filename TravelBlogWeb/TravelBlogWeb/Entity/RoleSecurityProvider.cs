using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity
{
    public class RoleSecurityProvider
    {
        DataContext db = new DataContext();
        
        public bool IsUserAdmin(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            return user != null && user.IsAdmin;
        }
    }
}