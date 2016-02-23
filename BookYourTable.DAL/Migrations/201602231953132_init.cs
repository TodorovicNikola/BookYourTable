namespace BookYourTable.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        GuestSenderID = c.Int(nullable: false),
                        GuestRecieverID = c.Int(nullable: false),
                        Confirmed = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.GuestSenderID, t.GuestRecieverID })
                .ForeignKey("dbo.Users", t => t.GuestRecieverID)
                .ForeignKey("dbo.Users", t => t.GuestSenderID)
                .Index(t => t.GuestSenderID)
                .Index(t => t.GuestRecieverID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        E_Mail = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 64),
                        FirstName = c.String(maxLength: 32),
                        LastName = c.String(maxLength: 32),
                        Address = c.String(maxLength: 256),
                        ImgUrl = c.String(maxLength: 128),
                        ConfirmedRegistration = c.Boolean(),
                        RestaurantID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.E_Mail, unique: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        GuestID = c.Int(nullable: false),
                        ReservationID = c.Int(nullable: false),
                        Accepted = c.Boolean(),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => new { t.GuestID, t.ReservationID })
                .ForeignKey("dbo.Users", t => t.GuestID)
                .ForeignKey("dbo.Reservations", t => t.ReservationID)
                .Index(t => t.GuestID)
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        GuestID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Users", t => t.GuestID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.GuestID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.ReservationRealizations",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        Time = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TableID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        ReservationID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.Date, t.Time, t.TableID, t.RestaurantID })
                .ForeignKey("dbo.Reservations", t => t.ReservationID)
                .ForeignKey("dbo.Tables", t => new { t.TableID, t.RestaurantID })
                .Index(t => new { t.TableID, t.RestaurantID })
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Capacity = c.Int(),
                        CellNumber = c.Int(nullable: false),
                        Description = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TableID, t.RestaurantID })
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 256),
                        ImgUrl = c.String(maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 256),
                        Configured = c.Boolean(nullable: false),
                        TablesMatrixWidth = c.Int(),
                        TablesMatrixHeight = c.Int(),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 2048),
                        Price = c.Decimal(nullable: false, precision: 6, scale: 2),
                        ImgUrl = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MenuItemID, t.RestaurantID })
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "GuestSenderID", "dbo.Users");
            DropForeignKey("dbo.Friendships", "GuestRecieverID", "dbo.Users");
            DropForeignKey("dbo.Invitations", "ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.ReservationRealizations", new[] { "TableID", "RestaurantID" }, "dbo.Tables");
            DropForeignKey("dbo.Tables", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Users", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.MenuItems", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.ReservationRealizations", "ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "GuestID", "dbo.Users");
            DropForeignKey("dbo.Invitations", "GuestID", "dbo.Users");
            DropIndex("dbo.MenuItems", new[] { "RestaurantID" });
            DropIndex("dbo.Tables", new[] { "RestaurantID" });
            DropIndex("dbo.ReservationRealizations", new[] { "ReservationID" });
            DropIndex("dbo.ReservationRealizations", new[] { "TableID", "RestaurantID" });
            DropIndex("dbo.Reservations", new[] { "RestaurantID" });
            DropIndex("dbo.Reservations", new[] { "GuestID" });
            DropIndex("dbo.Invitations", new[] { "ReservationID" });
            DropIndex("dbo.Invitations", new[] { "GuestID" });
            DropIndex("dbo.Users", new[] { "RestaurantID" });
            DropIndex("dbo.Users", new[] { "E_Mail" });
            DropIndex("dbo.Friendships", new[] { "GuestRecieverID" });
            DropIndex("dbo.Friendships", new[] { "GuestSenderID" });
            DropTable("dbo.MenuItems");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Tables");
            DropTable("dbo.ReservationRealizations");
            DropTable("dbo.Reservations");
            DropTable("dbo.Invitations");
            DropTable("dbo.Users");
            DropTable("dbo.Friendships");
        }
    }
}
