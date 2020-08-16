using ExQuizIt.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public class QuestionsRepo : IQuestionsRepo
	{

		private readonly string connectionString;
		private readonly ExQuizItDbContext context;

		public QuestionsRepo(ExQuizItDbContext exQuizItDbContext)
		{
			this.context = exQuizItDbContext;
		}
		public async Task<Question> Add(Question question)
		{
			try
			{
				var result = context.Questions.AddAsync(question);
				await context.SaveChangesAsync();
				return question;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}

		public Task Delete(int QuestionId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
		{
			var res = await context.Questions.Include(s => s.Game).OrderBy(s => s.QuestionNumber).ToListAsync();
			return res;
		}

		public Task<Question> GetQuestionForIdAsync(string QuestionId)
		{
			throw new NotImplementedException();
		}

		public Task<Question> Update(Question Question)
		{
			throw new NotImplementedException();
		}
	}
}
