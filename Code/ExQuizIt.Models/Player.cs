using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExQuizIt.Models
{
	public class Player : User
	{
		[DefaultValue(0)]
		public int GamesPlayed { get; set; }
		public ICollection<GamePlayer> GamePlayers { get; set; }
	}
}
