namespace webnhahangasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingFoods",
                c => new
                    {
                        BookingFoodId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingFoodId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .ForeignKey("dbo.Foods", t => t.FoodId)
                .Index(t => t.BookingId)
                .Index(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.BookingFoods", "BookingId", "dbo.Bookings");
            DropIndex("dbo.BookingFoods", new[] { "FoodId" });
            DropIndex("dbo.BookingFoods", new[] { "BookingId" });
            DropTable("dbo.BookingFoods");
        }
    }
}
