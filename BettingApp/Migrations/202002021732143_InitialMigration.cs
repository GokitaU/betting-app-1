namespace BettingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminCashDesk",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdminID = c.Int(nullable: false),
                        Administrator_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administrator", t => t.Administrator_ID)
                .Index(t => t.Administrator_ID);
            
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        AdminPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AvailableBet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        AdministratorID = c.Int(nullable: false),
                        TeamHWinMultiplier = c.Double(nullable: false),
                        TeamAWinMultiplier = c.Double(nullable: false),
                        DrawMultiplier = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administrator", t => t.AdministratorID, cascadeDelete: true)
                .ForeignKey("dbo.Match", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId)
                .Index(t => t.AdministratorID);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamHId = c.Int(nullable: false),
                        TeamAId = c.Int(nullable: false),
                        FinalResult = c.Int(nullable: false),
                        OtherResult = c.String(),
                        MatchStartDateTime = c.DateTime(nullable: false),
                        MatchIsOver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamAId)
                .ForeignKey("dbo.Team", t => t.TeamHId)
                .Index(t => t.TeamHId)
                .Index(t => t.TeamAId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LegaueID = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        InitialSummerBudjet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AveContractPerPLayer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        League_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.League", t => t.League_ID)
                .Index(t => t.League_ID);
            
            CreateTable(
                "dbo.League",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        LeagueName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MatchOMInterim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OtherMultiplierID = c.Int(nullable: false),
                        AvailableBetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvailableBet", t => t.AvailableBetID, cascadeDelete: true)
                .ForeignKey("dbo.OtherMultiplier", t => t.OtherMultiplierID, cascadeDelete: true)
                .Index(t => t.OtherMultiplierID)
                .Index(t => t.AvailableBetID);
            
            CreateTable(
                "dbo.OtherMultiplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Multiplier = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAvailableInterim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AvailableBetID = c.Int(nullable: false),
                        UserPlacedBetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvailableBet", t => t.AvailableBetID, cascadeDelete: true)
                .ForeignKey("dbo.UserPlacedBet", t => t.UserPlacedBetID, cascadeDelete: true)
                .Index(t => t.AvailableBetID)
                .Index(t => t.UserPlacedBetID);
            
            CreateTable(
                "dbo.UserPlacedBet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResultBetByUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        DateBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserWallet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWallet", "UserID", "dbo.User");
            DropForeignKey("dbo.UserAvailableInterim", "UserPlacedBetID", "dbo.UserPlacedBet");
            DropForeignKey("dbo.UserPlacedBet", "UserID", "dbo.User");
            DropForeignKey("dbo.UserAvailableInterim", "AvailableBetID", "dbo.AvailableBet");
            DropForeignKey("dbo.MatchOMInterim", "OtherMultiplierID", "dbo.OtherMultiplier");
            DropForeignKey("dbo.MatchOMInterim", "AvailableBetID", "dbo.AvailableBet");
            DropForeignKey("dbo.AvailableBet", "MatchId", "dbo.Match");
            DropForeignKey("dbo.Match", "TeamHId", "dbo.Team");
            DropForeignKey("dbo.Match", "TeamAId", "dbo.Team");
            DropForeignKey("dbo.Team", "League_ID", "dbo.League");
            DropForeignKey("dbo.AvailableBet", "AdministratorID", "dbo.Administrator");
            DropForeignKey("dbo.AdminCashDesk", "Administrator_ID", "dbo.Administrator");
            DropIndex("dbo.UserWallet", new[] { "UserID" });
            DropIndex("dbo.UserPlacedBet", new[] { "UserID" });
            DropIndex("dbo.UserAvailableInterim", new[] { "UserPlacedBetID" });
            DropIndex("dbo.UserAvailableInterim", new[] { "AvailableBetID" });
            DropIndex("dbo.MatchOMInterim", new[] { "AvailableBetID" });
            DropIndex("dbo.MatchOMInterim", new[] { "OtherMultiplierID" });
            DropIndex("dbo.Team", new[] { "League_ID" });
            DropIndex("dbo.Match", new[] { "TeamAId" });
            DropIndex("dbo.Match", new[] { "TeamHId" });
            DropIndex("dbo.AvailableBet", new[] { "AdministratorID" });
            DropIndex("dbo.AvailableBet", new[] { "MatchId" });
            DropIndex("dbo.AdminCashDesk", new[] { "Administrator_ID" });
            DropTable("dbo.UserWallet");
            DropTable("dbo.User");
            DropTable("dbo.UserPlacedBet");
            DropTable("dbo.UserAvailableInterim");
            DropTable("dbo.OtherMultiplier");
            DropTable("dbo.MatchOMInterim");
            DropTable("dbo.League");
            DropTable("dbo.Team");
            DropTable("dbo.Match");
            DropTable("dbo.AvailableBet");
            DropTable("dbo.Administrator");
            DropTable("dbo.AdminCashDesk");
        }
    }
}
