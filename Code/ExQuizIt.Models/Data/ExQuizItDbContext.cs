using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExQuizIt.Models;

namespace ExQuizIt.Models.Data
{
	public class ExQuizItDbContext : IdentityDbContext<User>
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Game> Games { get; set; }

		public DbSet<Player> Players { get; set; }
		public DbSet<GamePlayer> GamePlayers { get; set; }

		public DbSet<Quizmaster> Quizmasters { get; set; }

		public ExQuizItDbContext(DbContextOptions<ExQuizItDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); //must voor identity 
			modelBuilder.Entity<GamePlayer>(entity =>
			{
				entity.HasKey(e => new { e.GamePlayerId});
			});

			modelBuilder.Entity<GamePlayer>()
				.HasOne(gp => gp.Player)
				.WithMany(p => p.GamePlayers)
				.HasForeignKey(gp => gp.PlayerId);

			modelBuilder.Entity<GamePlayer>()
				.HasOne(gp => gp.Game)
				.WithMany(g => g.GamePlayers)
				.HasForeignKey(gp => gp.GameId);
		}
	}
}
