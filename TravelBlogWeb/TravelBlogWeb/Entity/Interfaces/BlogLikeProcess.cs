using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity.Interfaces
{
    public class BlogLikeProcess : ICrud<BlogLike>
    {
        DataContext db =new DataContext();
        public string Add(BlogLike entity)
        {
            string result = "";
            try
            {
                var like = db.BlogLikes.FirstOrDefault(x => x.BlogPostId == entity.BlogPostId && x.UserId==entity.UserId);

                if (like == null)
                {


                    db.BlogLikes.Add(entity);

                    db.SaveChanges();
                    result = entity.BlogPostId + " Liked Successfully";
                }
                else
                {
                    result = entity.BlogPostId + " can't liked!";
                }
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }

            return result;
        }

        public string Delete(int id)
        {
            string result = "";
            
            try
            {
                var like = db.BlogLikes.FirstOrDefault(x => x.Id==id);

                if (like != null)
                {
                    db.BlogLikes.Remove(like);
                    db.SaveChanges();
                    result = like.Id + " Like removed successfully";
                }
                else
                {
                    result = like.Id + " Like not found!";
                }
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }

            return result;
        }

        
        public BlogLike Get(int id)
        {
            throw new NotImplementedException();
        }
        public int GetBlogCount(int id)
        {
            int likeCount = db.BlogLikes.Where(comment => comment.BlogPostId == id).Count();
                
            return likeCount;
        }

        public List<BlogLike> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogLike entity, int id)
        {
            throw new NotImplementedException();
        }

        bool ICrud<BlogLike>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}