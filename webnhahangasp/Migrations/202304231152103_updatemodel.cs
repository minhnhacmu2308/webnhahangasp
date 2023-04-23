namespace webnhahangasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "FullName", c => c.String());
            AddColumn("dbo.Bookings", "Phone", c => c.String());
            AddColumn("dbo.Bookings", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Email");
            DropColumn("dbo.Bookings", "Phone");
            DropColumn("dbo.Bookings", "FullName");
        }
    }
}
