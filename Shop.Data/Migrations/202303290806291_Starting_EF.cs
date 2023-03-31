//namespace Shop.Data.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Starting_EF : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Categories",
//                c => new
//                    {
//                        ID = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false),
//                        Description = c.String(),
//                        ImageUrl = c.String(),
//                    })
//                .PrimaryKey(t => t.ID);
            
//            CreateTable(
//                "dbo.Products",
//                c => new
//                    {
//                        ID = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false),
//                        Price = c.Int(nullable: false),
//                        Description = c.String(),
//                        ImageUrl = c.String(),
//                        CategoryID = c.Int(nullable: false),
//                        Quantity = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.ID)
//                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
//                .Index(t => t.CategoryID);
            
//            CreateTable(
//                "dbo.Users",
//                c => new
//                    {
//                        ID = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                        Email = c.String(nullable: false),
//                        Password = c.String(nullable: false, maxLength: 100),
//                    })
//                .PrimaryKey(t => t.ID);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
//            DropIndex("dbo.Products", new[] { "CategoryID" });
//            DropTable("dbo.Users");
//            DropTable("dbo.Products");
//            DropTable("dbo.Categories");
//        }
//    }
//}
