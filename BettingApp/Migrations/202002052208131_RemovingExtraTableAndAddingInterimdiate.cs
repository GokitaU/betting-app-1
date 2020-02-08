namespace BettingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingExtraTableAndAddingInterimdiate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAvailableInterim", "AvailableBetID", "dbo.AvailableBet");
            DropForeignKey("dbo.UserAvailableInterim", "UserPlacedBetID", "dbo.UserPlacedBet");
            DropIndex("dbo.UserAvailableInterim", new[] { "AvailableBetID" });
            DropIndex("dbo.UserAvailableInterim", new[] { "UserPlacedBetID" });
            CreateTable(
                "dbo.UserPlacedBetOtherMultiplier",
                c => new
                    {
                        OtherMultiplierID = c.Int(nullable: false),
                        UserPlacedBets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OtherMultiplierID, t.UserPlacedBets })
                .ForeignKey("dbo.UserPlacedBet", t => t.OtherMultiplierID, cascadeDelete: true)
                .ForeignKey("dbo.OtherMultiplier", t => t.UserPlacedBets, cascadeDelete: true)
                .Index(t => t.OtherMultiplierID)
                .Index(t => t.UserPlacedBets);
            
            AddColumn("dbo.UserPlacedBet", "AvailableBetID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserPlacedBet", "AvailableBetID");
            AddForeignKey("dbo.UserPlacedBet", "AvailableBetID", "dbo.AvailableBet", "ID", cascadeDelete: true);
            DropTable("dbo.UserAvailableInterim");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAvailableInterim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AvailableBetID = c.Int(nullable: false),
                        UserPlacedBetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.UserPlacedBetOtherMultiplier", "UserPlacedBets", "dbo.OtherMultiplier");
            DropForeignKey("dbo.UserPlacedBetOtherMultiplier", "OtherMultiplierID", "dbo.UserPlacedBet");
            DropForeignKey("dbo.UserPlacedBet", "AvailableBetID", "dbo.AvailableBet");
            DropIndex("dbo.UserPlacedBetOtherMultiplier", new[] { "UserPlacedBets" });
            DropIndex("dbo.UserPlacedBetOtherMultiplier", new[] { "OtherMultiplierID" });
            DropIndex("dbo.UserPlacedBet", new[] { "AvailableBetID" });
            DropColumn("dbo.UserPlacedBet", "AvailableBetID");
            DropTable("dbo.UserPlacedBetOtherMultiplier");
            CreateIndex("dbo.UserAvailableInterim", "UserPlacedBetID");
            CreateIndex("dbo.UserAvailableInterim", "AvailableBetID");
            AddForeignKey("dbo.UserAvailableInterim", "UserPlacedBetID", "dbo.UserPlacedBet", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserAvailableInterim", "AvailableBetID", "dbo.AvailableBet", "ID", cascadeDelete: true);
        }
    }
}
