namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (1, 'Hangover', 2, '20120618 10:34:09 AM', '20210618 10:34:09 AM', 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (2, 'Die Hard', 1, '20130618 10:34:09 AM', '20210618 10:34:09 AM', 3)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (3, 'The Terminator', 1, '20120618 10:34:09 AM', '20210618 10:34:09 AM', 1)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (4, 'Toy Story', 3, '20100618 10:34:09 AM', '20210618 10:34:09 AM', 0)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES (5, 'Titanic', 4, '20090618 10:34:09 AM', '20210618 10:34:09 AM', 10)");
            Sql("SET IDENTITY_INSERT Movies OFF");

        }
        
        public override void Down()
        {
        }
    }
}
