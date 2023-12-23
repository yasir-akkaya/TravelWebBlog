namespace TravelBlogWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BlogPostId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BlogLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId)
                .Index(t => t.UserId)
                .Index(t => t.BlogPostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityBlogRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId)
                .Index(t => t.BlogPostId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityBlogRelations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.CityBlogRelations", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogLikes", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.CityBlogRelations", new[] { "BlogPostId" });
            DropIndex("dbo.CityBlogRelations", new[] { "CityId" });
            DropIndex("dbo.BlogLikes", new[] { "BlogPostId" });
            DropIndex("dbo.BlogLikes", new[] { "UserId" });
            DropIndex("dbo.BlogPosts", new[] { "UserId" });
            DropIndex("dbo.BlogComments", new[] { "BlogPostId" });
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            DropTable("dbo.Cities");
            DropTable("dbo.CityBlogRelations");
            DropTable("dbo.Users");
            DropTable("dbo.BlogLikes");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogComments");
        }
    }
}
