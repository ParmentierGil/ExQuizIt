using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public interface IQuestionsRepo
	{
		Task<IEnumerable<Question>> GetAllQuestionsAsync(); 
		Task<Question> GetQuestionForIdAsync(string QuestionId);

		//CREATE (Async) 
		Task<Question> Add(Question Question);

		//UPDATE (Async) 
		Task<Question> Update(Question Question);

		//DELETE (Async) 
		Task Delete(int QuestionId);

	}
}
