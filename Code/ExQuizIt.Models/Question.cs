using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ExQuizIt.Models
{
	public class Question
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuestionId { get; set; }
		public int QuestionNumber { get; set; }
		public int GameId { get; set; }
		public Game Game { get; set; }

		[MaxLength(100)]
		[DisplayName("Question")]
		[Required]
		public string QuestionText { get; set; }

		[MaxLength(200)]
		[DisplayName("Right Answer")]
		[Required]
		public string CorrectAnswer { get; set; }

		[MaxLength(200)]
		[DisplayName("Wrong Answer 1")]
		[Required]
		public string WrongAnswer1 { get; set; }

		[MaxLength(200)]
		[DisplayName("Wrong Answer 2")]
		[Required]
		public string WrongAnswer2 { get; set; }

		[MaxLength(200)]
		[DisplayName("Wrong Answer 3")]
		[Required]
		public string WrongAnswer3 { get; set; }
	}
}
