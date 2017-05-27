namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAddedToDB, StockNumber) VALUES('Ace Ventura Pet Detective','Comedy',10/05/1992,6/5/2017,7)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAddedToDB, StockNumber) VALUES('Fast and Furious 5','Action',09/05/2013,3/6/2017,15)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAddedToDB, StockNumber) VALUES('Saving Private Ryan','Action',10/05/1995,6/8/2017,4)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAddedToDB, StockNumber) VALUES('Momento','Thriller',12/07/200,6/5/2017,6)");
        }
        
        public override void Down()
        {
        }
    }
}
