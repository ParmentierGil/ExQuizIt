using ExQuizIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExQuizIt.Web.Models
{
	public class ScoreboardVM
	{
		public IEnumerable<GamePlayer> GamePlayers { get; set; }
	}
}
