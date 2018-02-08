namespace QualityOrganizationWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePublication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ResearchField = c.String(nullable: false),
                        Authors = c.String(nullable: false),
                        National = c.Boolean(nullable: false),
                        ResearchYear = c.Int(nullable: false),
                        PubType = c.Int(nullable: false),
                        Details = c.String(nullable: false),
                        Identifier = c.String(),
                        Abstract = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publications");
        }
    }
}
