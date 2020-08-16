using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public interface IGamesRepo
	{
		Task<IEnumerable<Game>> GetAllGamesAsync(); 
		Task<Game> GetGameForIdAsync(int GameId);

		//CREATE (Async) 
		Task<Game> Add(Game Game);

		//UPDATE (Async) 
		Task<Game> Update(Game Game);

		//DELETE (Async) 
		Task Delete(int GameId);

	}
}
