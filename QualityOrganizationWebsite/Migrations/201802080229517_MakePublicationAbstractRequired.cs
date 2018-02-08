namespace QualityOrganizationWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePublicationAbstractRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publications", "Abstract", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publications", "Abstract", c => c.String());
        }
    }
}
