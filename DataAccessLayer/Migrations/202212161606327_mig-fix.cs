namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Writers", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Writers", new[] { "Writer_WriterID" });
            DropColumn("dbo.Writers", "Writer_WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Writers", "Writer_WriterID");
            AddForeignKey("dbo.Writers", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
