namespace MobileShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            AddColumn("dbo.Products", "Brand", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Brand_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Brand_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Products", "Brand");
            CreateIndex("dbo.Products", "Brand_Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
