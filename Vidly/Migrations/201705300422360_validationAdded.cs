namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "MemberShipName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "MemberShipName", c => c.String());
        }
    }
}
