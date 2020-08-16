using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Repos
{
	public interface IQuizmastersRepo
	{
		Task<IEnumerable<Quizmaster>> GetAllQuizmastersAsync(); 
		Task<Quizmaster> GetQuizmasterForIdAsync(string QuizmasterId);

		//CREATE (Async) 
		Task<Quizmaster> Add(Quizmaster Quizmaster);

		//UPDATE (Async) 
		Task<Quizmaster> Update(Quizmaster Quizmaster);

		//DELETE (Async) 
		Task Delete(int QuizmasterId);

	}
}
