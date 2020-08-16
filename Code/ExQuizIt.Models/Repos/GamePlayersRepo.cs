using ExQuizIt.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public class GamePlayersRepo : IGamePlayersRepo
	{

		private readonly string connectionString;
		private readonly ExQuizItDbContext context;

		public GamePlayersRepo(ExQuizItDbContext exQuizItDbContext)
		{
			this.context = exQuizItDbContext;
		}

		public async Task<GamePlayer> Add(GamePlayer gamePlayer)
		{
			try
			{
				var result = context.GamePlayers.AddAsync(gamePlayer);
				await context.SaveChangesAsync();
				return gamePlayer;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}

		public async Task<IEnumerable<GamePlayer>> GetAllGamePlayersAsync()
		{
			var res = await context.GamePlayers
				.Include(s => s.Player)
				.Include(s => s.Game)
				.OrderByDescending(s => s.Score).ToListAsync();
			return res;
		}

		public Task<GamePlayer> GetGamePlayersForPlayerIdAsync(string PlayerId)
		{
			throw new NotImplementedException();
		}

		public async Task<GamePlayer> Update(GamePlayer gamePlayer)
		{
			try
			{
				var gpToChange = await context.GamePlayers.Include(s => s.Player)
										.Include(s => s.Game)
										.Where(s => s.GamePlayerId == gamePlayer.GamePlayerId)
										.FirstOrDefaultAsync();

				gpToChange.Score = gamePlayer.Score;

				var result = context.GamePlayers.Update(gpToChange);
				context.Entry<GamePlayer>(gpToChange).State = EntityState.Modified;
				await context.SaveChangesAsync();
				return gpToChange;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}
	}
}
