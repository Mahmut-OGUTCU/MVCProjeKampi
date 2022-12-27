namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migremovecloumntoheading : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "HeadingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingDate", c => c.DateTime(nullable: false));
        }
    }
}
