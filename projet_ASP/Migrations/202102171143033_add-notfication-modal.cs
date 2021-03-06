namespace projet_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnotficationmodal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        idNotification = c.Int(nullable: false, identity: true),
                        idOroginalNotification = c.Int(nullable: false),
                        type = c.String(),
                        hint = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idNotification)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "ApplicationUserID" });
            DropTable("dbo.Notifications");
        }
    }
}
