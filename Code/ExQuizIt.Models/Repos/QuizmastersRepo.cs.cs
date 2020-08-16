using ExQuizIt.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public class QuizmastersRepo : IQuizmastersRepo
	{

		private readonly string connectionString;
		private readonly ExQuizItDbContext context;

		public QuizmastersRepo(ExQuizItDbContext exQuizItDbContext)
		{
			this.context = exQuizItDbContext;
		}
		public async Task<Quizmaster> Add(Quizmaster Quizmaster)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int QuizmasterId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Quizmaster>> GetAllQuizmastersAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<Quizmaster> GetQuizmasterForIdAsync(string QuizmasterId)
		{
			var res = await context.Quizmasters
				.Include(s => s.GamesMade)
				.ThenInclude(s => s.Questions)
				.Where(s => s.Id == QuizmasterId).FirstOrDefaultAsync();
			return res;
		}

		public Task<Quizmaster> Update(Quizmaster Quizmaster)
		{
			throw new NotImplementedException();
		}
	}
}
