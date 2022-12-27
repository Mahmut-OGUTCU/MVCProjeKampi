namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "ContactCreatedID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "ContactCreatedID", c => c.Int(nullable: false));
        }
    }
}
