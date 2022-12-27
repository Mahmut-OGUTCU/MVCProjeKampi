namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddedisActivecloumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CategoryisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Headings", "HeadingisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contents", "ContentisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "ContactisActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactisActive");
            DropColumn("dbo.Writers", "WriterisActive");
            DropColumn("dbo.Contents", "ContentisActive");
            DropColumn("dbo.Headings", "HeadingisActive");
            DropColumn("dbo.Categories", "CategoryisActive");
            DropColumn("dbo.Abouts", "AboutisActive");
        }
    }
}
