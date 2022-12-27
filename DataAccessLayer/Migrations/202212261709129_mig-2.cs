namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "MessageisDraft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageisDraft", c => c.Boolean(nullable: false));
        }
    }
}
