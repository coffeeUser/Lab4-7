namespace TrialTwitter.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TweetChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tweets", new[] { "Author_Id" });
            DropColumn("dbo.Tweets", "AuthorId");
            RenameColumn(table: "dbo.Tweets", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Tweets", "Content", c => c.String(maxLength: 240));
            AlterColumn("dbo.Tweets", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tweets", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tweets", new[] { "AuthorId" });
            AlterColumn("dbo.Tweets", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tweets", "Content", c => c.String());
            RenameColumn(table: "dbo.Tweets", name: "AuthorId", newName: "Author_Id");
            AddColumn("dbo.Tweets", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tweets", "Author_Id");
        }
    }
}
