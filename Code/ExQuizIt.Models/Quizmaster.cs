using System;
using System.Collections.Generic;
using System.Text;

namespace ExQuizIt.Models
{
	public class Quizmaster : User
	{
		public IEnumerable<Game> GamesMade { get; set; }
	}
}
