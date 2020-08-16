using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExQuizIt.Models
{
	public class GamePlayer
	{
		public int GameId { get; set; }
		public Game Game { get; set; }

		public string PlayerId { get; set; }
		public Player Player { get; set; }

		public string GamePlayerId { get; set; }

		public DateTime TimeStartPlaying { get; set; }

		public int QuestionNumber { get; set; }
		public int Score { get; set; }
	}
}
