using BettingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BettingApp.Data
{
    public class BettingAppContext : DbContext
    {
        public BettingAppContext () : base ("BettingAppContext")
        { }

        public DbSet<AdminCashDesk> AdminCashDesks { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AvailableBet> AvailableBets { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<OtherMultiplier> OtherMultipliers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserPlacedBet> UserPlacedBets { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }
        public DbSet<MatchOMInterim> MatchOMInterims { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired(m => m.TeamH)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.TeamHId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.TeamA)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.TeamAId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserPlacedBet>()
                  .HasMany(u => u.OtherMultipliers)
                  .WithMany (o => o.UserPlacedBets)
                  .Map (t => t.MapLeftKey("OtherMultiplierID")
                  .MapRightKey("UserPlacedBets")
                  .ToTable("UserPlacedBetOtherMultiplier")
                  )
                  ;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}