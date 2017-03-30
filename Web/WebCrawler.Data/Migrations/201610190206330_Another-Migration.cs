namespace WebCrawler.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReviewRating = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Vendor = c.String(),
                        ProductUrl = c.String(),
                        Genre = c.String(),
                        Platform = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
