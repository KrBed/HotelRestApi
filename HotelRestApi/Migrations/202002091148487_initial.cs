namespace HotelRestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationGuests",
                c => new
                    {
                        ReservationId = c.Int(nullable: false),
                        GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReservationId, t.GuestId })
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId)
                .Index(t => t.GuestId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationCode = c.String(nullable: false, maxLength: 10),
                        CreationDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookInDate = c.DateTime(nullable: false),
                        BookOutDate = c.DateTime(nullable: false),
                        Currency = c.String(nullable: false),
                        Commission = c.Double(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuests", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.ReservationGuests", "GuestId", "dbo.Guests");
            DropIndex("dbo.ReservationGuests", new[] { "GuestId" });
            DropIndex("dbo.ReservationGuests", new[] { "ReservationId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.ReservationGuests");
            DropTable("dbo.Guests");
        }
    }
}
