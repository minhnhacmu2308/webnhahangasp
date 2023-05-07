namespace webnhahangasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolnews : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "Created_by");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Created_by", c => c.Int(nullable: false));
        }
    }
}
