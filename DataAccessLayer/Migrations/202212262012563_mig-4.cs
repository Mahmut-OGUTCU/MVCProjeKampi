namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contents", "ContentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
        }
    }
}
