namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberShipNameRecordinserted3 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MemberShipName = 'Pay as you go' WHERE Id = 1; ");
            Sql("UPDATE MembershipTypes SET MemberShipName = 'Monthly' WHERE Id = 2; ");
            Sql("UPDATE MembershipTypes SET MemberShipName = 'Quarterly' WHERE Id = 3; ");
            Sql("UPDATE MembershipTypes SET MemberShipName = 'Yearly' WHERE Id = 4; ");
        }
        
        public override void Down()
        {
        }
    }
}
