namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLimitOfRentedOnCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LimitOfMoviesRented", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MoviesRented", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MoviesRented");
            DropColumn("dbo.Customers", "LimitOfMoviesRented");
        }
    }
}
