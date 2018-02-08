namespace QualityOrganizationWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Publications", "JournalName");
            DropColumn("dbo.Publications", "JournalDOI");
            DropColumn("dbo.Publications", "ConfranceDetails");
            DropColumn("dbo.Publications", "BookName");
            DropColumn("dbo.Publications", "BookISSN");
            DropColumn("dbo.Publications", "ResearchFieldsList_DataGroupField");
            DropColumn("dbo.Publications", "ResearchFieldsList_DataTextField");
            DropColumn("dbo.Publications", "ResearchFieldsList_DataValueField");
            DropColumn("dbo.Publications", "ResearchYearsList_DataGroupField");
            DropColumn("dbo.Publications", "ResearchYearsList_DataTextField");
            DropColumn("dbo.Publications", "ResearchYearsList_DataValueField");
            DropColumn("dbo.Publications", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publications", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Publications", "ResearchYearsList_DataValueField", c => c.String());
            AddColumn("dbo.Publications", "ResearchYearsList_DataTextField", c => c.String());
            AddColumn("dbo.Publications", "ResearchYearsList_DataGroupField", c => c.String());
            AddColumn("dbo.Publications", "ResearchFieldsList_DataValueField", c => c.String());
            AddColumn("dbo.Publications", "ResearchFieldsList_DataTextField", c => c.String());
            AddColumn("dbo.Publications", "ResearchFieldsList_DataGroupField", c => c.String());
            AddColumn("dbo.Publications", "BookISSN", c => c.String(maxLength: 100));
            AddColumn("dbo.Publications", "BookName", c => c.String(maxLength: 100));
            AddColumn("dbo.Publications", "ConfranceDetails", c => c.String(maxLength: 100));
            AddColumn("dbo.Publications", "JournalDOI", c => c.String(maxLength: 100));
            AddColumn("dbo.Publications", "JournalName", c => c.String(maxLength: 100));
        }
    }
}
