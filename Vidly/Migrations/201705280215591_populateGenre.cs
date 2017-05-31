namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (type) VALUES(  'Action')");
            Sql("INSERT INTO Genres (type) VALUES('Comedy')");
            Sql("INSERT INTO Genres (type) VALUES('Romance')");
            Sql("INSERT INTO Genres (type) VALUES('Family')");
            Sql("INSERT INTO Genres (type) VALUES('Thriller')");


        }

        public override void Down()
        {
        }
    }
}
