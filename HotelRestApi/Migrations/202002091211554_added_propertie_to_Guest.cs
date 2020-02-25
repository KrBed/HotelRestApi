namespace HotelRestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_propertie_to_Guest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guests", "Telephone", c => c.String());
            AddColumn("dbo.Guests", "Address", c => c.String());
            AddColumn("dbo.Guests", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guests", "City");
            DropColumn("dbo.Guests", "Address");
            DropColumn("dbo.Guests", "Telephone");
        }
    }
}
