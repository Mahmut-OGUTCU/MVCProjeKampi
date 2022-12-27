namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddcloumnContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactisRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactisRead");
        }
    }
}
