namespace MobileShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BrandName = c.String(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 30),
                        OS = c.Int(nullable: false),
                        RAM = c.Int(nullable: false),
                        InternalMemory = c.Int(nullable: false),
                        CameraMP = c.Int(nullable: false),
                        DisplaySize = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Brand_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id, cascadeDelete: true)
                .Index(t => t.Brand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
