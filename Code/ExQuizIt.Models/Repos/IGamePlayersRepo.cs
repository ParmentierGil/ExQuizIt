using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public interface IGamePlayersRepo
	{
		Task<IEnumerable<GamePlayer>> GetAllGamePlayersAsync(); 
		Task<GamePlayer> GetGamePlayersForPlayerIdAsync(string PlayerId);

		//CREATE (Async) 
		Task<GamePlayer> Add(GamePlayer gamePlayer);

		//UPDATE (Async) 
		Task<GamePlayer> Update(GamePlayer gamePlayer);


	}
}
