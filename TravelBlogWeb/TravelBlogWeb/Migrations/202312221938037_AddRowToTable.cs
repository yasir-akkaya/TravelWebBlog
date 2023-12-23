namespace TravelBlogWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowToTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogComments", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogComments", "IsActive");
        }
    }
}
