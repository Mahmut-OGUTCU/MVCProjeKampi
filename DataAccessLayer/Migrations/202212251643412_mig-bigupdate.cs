namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migbigupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Abouts", "AboutCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Abouts", "AboutUpdatedID", c => c.Int());
            AddColumn("dbo.Abouts", "AboutUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Admins", "AdminCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "AdminCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "AdminisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminUpdatedID", c => c.Int());
            AddColumn("dbo.Admins", "AdminUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Categories", "CategoryCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "CategoryUpdatedID", c => c.Int());
            AddColumn("dbo.Categories", "CategoryUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Headings", "HeadingCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Headings", "HeadingCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Headings", "HeadingUpdatedID", c => c.Int());
            AddColumn("dbo.Headings", "HeadingUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Contents", "ContentCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "ContentCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contents", "ContentUpdatedID", c => c.Int());
            AddColumn("dbo.Contents", "ContentUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Writers", "WriterCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Writers", "WriterUpdatedID", c => c.Int());
            AddColumn("dbo.Writers", "WriterUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Contacts", "ContactCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "ContactCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "ContactUpdatedID", c => c.Int());
            AddColumn("dbo.Contacts", "ContactUpdatedDate", c => c.DateTime());
            AddColumn("dbo.Messages", "MessageCreatedID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "MessageCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "MessageisActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageUpdatedID", c => c.Int());
            AddColumn("dbo.Messages", "MessageUpdatedDate", c => c.DateTime());
            DropColumn("dbo.Contacts", "ContactDate");
            DropColumn("dbo.Messages", "MessageDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "MessageUpdatedDate");
            DropColumn("dbo.Messages", "MessageUpdatedID");
            DropColumn("dbo.Messages", "MessageisActive");
            DropColumn("dbo.Messages", "MessageCreatedDate");
            DropColumn("dbo.Messages", "MessageCreatedID");
            DropColumn("dbo.Contacts", "ContactUpdatedDate");
            DropColumn("dbo.Contacts", "ContactUpdatedID");
            DropColumn("dbo.Contacts", "ContactCreatedDate");
            DropColumn("dbo.Contacts", "ContactCreatedID");
            DropColumn("dbo.Writers", "WriterUpdatedDate");
            DropColumn("dbo.Writers", "WriterUpdatedID");
            DropColumn("dbo.Writers", "WriterCreatedDate");
            DropColumn("dbo.Writers", "WriterCreatedID");
            DropColumn("dbo.Contents", "ContentUpdatedDate");
            DropColumn("dbo.Contents", "ContentUpdatedID");
            DropColumn("dbo.Contents", "ContentCreatedDate");
            DropColumn("dbo.Contents", "ContentCreatedID");
            DropColumn("dbo.Headings", "HeadingUpdatedDate");
            DropColumn("dbo.Headings", "HeadingUpdatedID");
            DropColumn("dbo.Headings", "HeadingCreatedDate");
            DropColumn("dbo.Headings", "HeadingCreatedID");
            DropColumn("dbo.Categories", "CategoryUpdatedDate");
            DropColumn("dbo.Categories", "CategoryUpdatedID");
            DropColumn("dbo.Categories", "CategoryCreatedDate");
            DropColumn("dbo.Categories", "CategoryCreatedID");
            DropColumn("dbo.Admins", "AdminUpdatedDate");
            DropColumn("dbo.Admins", "AdminUpdatedID");
            DropColumn("dbo.Admins", "AdminisActive");
            DropColumn("dbo.Admins", "AdminCreatedDate");
            DropColumn("dbo.Admins", "AdminCreatedID");
            DropColumn("dbo.Abouts", "AboutUpdatedDate");
            DropColumn("dbo.Abouts", "AboutUpdatedID");
            DropColumn("dbo.Abouts", "AboutCreatedDate");
            DropColumn("dbo.Abouts", "AboutCreatedID");
        }
    }
}
