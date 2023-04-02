namespace webnhahangasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                        Note = c.String(),
                        NumberPeople = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        TypeFoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Content = c.String(),
                        Created_at = c.String(),
                        Created_by = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Note = c.String(),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsPayment = c.Int(nullable: false),
                        Created_at = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.TypeFoods",
                c => new
                    {
                        TypeFoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeFoodId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        Image = c.String(),
                        Status = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                        Updated_by = c.Int(nullable: false),
                        PayTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.TypeFoods");
            DropTable("dbo.Roles");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.News");
            DropTable("dbo.Menus");
            DropTable("dbo.Foods");
            DropTable("dbo.Branches");
            DropTable("dbo.Bookings");
        }
    }
}
