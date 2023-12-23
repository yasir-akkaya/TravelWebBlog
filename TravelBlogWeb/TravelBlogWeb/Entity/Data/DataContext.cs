using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Entity.Data
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DbConnection") 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogLike> BlogLikes { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityBlogRelation> CityBlogRelations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.BlogPosts)
                .WithRequired(bp => bp.User)
                .HasForeignKey(bp => bp.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.BlogLikes)
                .WithRequired(bl => bl.BlogPost)
                .HasForeignKey(bl => bl.BlogPostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.BlogComments)
                .WithRequired(bc => bc.BlogPost)
                .HasForeignKey(bc => bc.BlogPostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CityBlogRelation>()
        .HasKey(cbr => cbr.Id);

            modelBuilder.Entity<CityBlogRelation>()
                .Property(cbr => cbr.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<CityBlogRelation>()
                .HasRequired(cbr => cbr.City)
                .WithMany(c => c.CityBlogRelations)
                .HasForeignKey(cbr => cbr.CityId)
                .WillCascadeOnDelete(false); 

            modelBuilder.Entity<CityBlogRelation>()
                .HasRequired(cbr => cbr.BlogPost)
                .WithMany(bp => bp.CityBlogRelations)
                .HasForeignKey(cbr => cbr.BlogPostId)
                .WillCascadeOnDelete(false); 




            base.OnModelCreating(modelBuilder);
        }


    }
}