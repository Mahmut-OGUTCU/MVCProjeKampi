namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterCreatedID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterCreatedID", c => c.Int(nullable: false));
        }
    }
}
