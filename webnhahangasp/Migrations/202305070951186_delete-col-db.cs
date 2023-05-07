namespace webnhahangasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecoldb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "Created_at");
            DropColumn("dbo.Users", "Created_by");
            DropColumn("dbo.Users", "Updated_at");
            DropColumn("dbo.Users", "Updated_by");
            DropColumn("dbo.Users", "PayTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PayTotal", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Updated_by", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Updated_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Created_by", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Created_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Image", c => c.String());
        }
    }
}
