using ExQuizIt.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public class PlayersRepo : IPlayersRepo
	{

		private readonly string connectionString;
		private readonly ExQuizItDbContext context;

		public PlayersRepo(ExQuizItDbContext exQuizItDbContext)
		{
			this.context = exQuizItDbContext;
		}
		public async Task<Player> Add(Player Player)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int PlayerId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Player>> GetAllPlayersAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<Player> GetPlayerForIdAsync(string PlayerId)
		{
			var res = await context.Players
				.Include(s => s.GamePlayers)
				.ThenInclude(s => s.Game)
				.Where(s => s.Id == PlayerId).FirstOrDefaultAsync();
			return res;
		}

		public Task<Player> Update(Player Player)
		{
			throw new NotImplementedException();
		}
	}
}
