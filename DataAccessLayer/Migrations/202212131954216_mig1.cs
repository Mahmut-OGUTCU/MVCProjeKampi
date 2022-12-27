namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "WriterID", c => c.Int());
            AddColumn("dbo.Writers", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Writers", "Writer_WriterID");
            AddForeignKey("dbo.Writers", "Writer_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Writers", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Writers", new[] { "Writer_WriterID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropColumn("dbo.Writers", "Writer_WriterID");
            DropColumn("dbo.Contents", "WriterID");
        }
    }
}
