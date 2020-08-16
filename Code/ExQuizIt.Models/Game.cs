using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExQuizIt.Models
{
	public class Game
	{
		public enum DifficultyType
		{
			Easy = 0,
			Hard = 1
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GameId { get; set; }

		[Required]
		[DefaultValue(DifficultyType.Easy)]
		public DifficultyType Difficulty { get; set; }

		[MaxLength(100)]
		[Required]
		[DefaultValue("Trivia")]
		public string Subject { get; set; }

		[Required]
		[Range(1, 20, ErrorMessage = "Please enter a value bigger than {1}")]
		[DisplayName("Number of questions")]
		[DefaultValue(10)]
		public int QuestionCount { get; set; }

		public IEnumerable<Question> Questions { get; set; }

		[DisplayName("Release time")]
		public DateTime TimeCreated { get; set; }

		public string QuizmasterId { get; set; }

		public Quizmaster Quizmaster { get; set; }

		public ICollection<GamePlayer> GamePlayers { get; set; }

		public bool Active { get; set; }
	}
}
