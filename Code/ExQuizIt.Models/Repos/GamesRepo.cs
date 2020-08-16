using ExQuizIt.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public class GamesRepo : IGamesRepo
	{

		private readonly string connectionString;
		private readonly ExQuizItDbContext context;

		public GamesRepo(ExQuizItDbContext exQuizItDbContext)
		{
			this.context = exQuizItDbContext;
		}
		public async Task<Game> Add(Game game)
		{
			try
			{
				var result = context.Games.AddAsync(game);
				await context.SaveChangesAsync();
				return game;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}

		public Task Delete(int GameId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Game>> GetAllGamesAsync()
		{
			var res = await context.Games
				.Include(s => s.Questions)
				.Include(s => s.GamePlayers)
					.ThenInclude(s => s.Player)
				.OrderByDescending(s => s.TimeCreated)
				.Where(s => s.Active == true)
				.ToListAsync();
			return res;
		}

		public async Task<Game> GetGameForIdAsync(int GameId)
		{
			var res = await context.Games
				.Include(s => s.Questions)
				.Include(s => s.GamePlayers)
					.ThenInclude(s => s.Player)
				.FirstOrDefaultAsync(s => s.GameId == GameId);
			return res;
		}

		public async Task<Game> Update(Game game)
		{
			try
			{
				var gameToChange = await context.Games.Include(s => s.Quizmaster)
										.Include(s => s.Questions)
										.Where(s => s.GameId == game.GameId)
										.FirstOrDefaultAsync();

				gameToChange.Questions = game.Questions;
				gameToChange.TimeCreated = game.TimeCreated;

				var result = context.Games.Update(gameToChange);
				context.Entry<Game>(gameToChange).State = EntityState.Modified;
				await context.SaveChangesAsync();
				return game;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}
	}
}
