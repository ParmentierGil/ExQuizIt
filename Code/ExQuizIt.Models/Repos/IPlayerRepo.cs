using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public interface IPlayersRepo
	{
		Task<IEnumerable<Player>> GetAllPlayersAsync(); 
		Task<Player> GetPlayerForIdAsync(string PlayerId);

		//CREATE (Async) 
		Task<Player> Add(Player Player);

		//UPDATE (Async) 
		Task<Player> Update(Player Player);

		//DELETE (Async) 
		Task Delete(int PlayerId);

	}
}
