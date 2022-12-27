namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddcloumnMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageisRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageisRead");
        }
    }
}
