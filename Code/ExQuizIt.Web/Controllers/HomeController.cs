using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExQuizIt.Models;
using ExQuizIt.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using ExQuizIt.Models.Repos;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;

namespace ExQuizIt.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

		private IGamesRepo _gamesRepo;
		private IQuizmastersRepo _quizmastersRepo;
		private IQuestionsRepo _questionsRepo;

		public HomeController(ILogger<HomeController> logger, IGamesRepo gamesRepo, IQuizmastersRepo quizmastersRepo, IQuestionsRepo questionsRepo)
		{
			_logger = logger;
			_gamesRepo = gamesRepo;
			_quizmastersRepo = quizmastersRepo;
			_questionsRepo = questionsRepo;
		}

		[Authorize(AuthenticationSchemes = AuthSchemes)]
		public IActionResult Index()
		{
			return View();
		}

		[Authorize(AuthenticationSchemes = AuthSchemes)]
		public async Task<IActionResult> Games()
		{
			IEnumerable<Game> games = await _gamesRepo.GetAllGamesAsync();
			return View(games);
		}

		[HttpGet]
		[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Quizmaster")]
		public async Task<IActionResult> CreateNewGame(string id)
		{
			Quizmaster qm = await _quizmastersRepo.GetQuizmasterForIdAsync(id);

			if (qm == null)
			{
				return NotFound();  //404
			}

			Game g = new Game()
			{
				Quizmaster = qm,
				QuizmasterId = qm.Id,
				Subject = "Trivia",
				Difficulty = Game.DifficultyType.Easy,
				QuestionCount = 10
			};

			g = await _gamesRepo.Add(g);

			return View(g);
		}

		[HttpPost]
		[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Quizmaster")]
		public async Task<IActionResult> CreateNewGame(Game game)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					throw new Exception("Validation Error");
				}

				Game g = await _gamesRepo.GetGameForIdAsync(game.GameId);

				if (g == null)
				{
					return NotFound();  //404
				}

				Question q = new Question()
				{
					QuestionNumber = 0,
					GameId = g.GameId,
					Game = g
	
				};

				g.Subject = game.Subject;
				g.Difficulty = game.Difficulty;
				g.QuestionCount = game.QuestionCount;

				g = await _gamesRepo.Update(g);

				g.Questions = new List<Question>()
				{
					q
				};

				return View("AddQuestion", q);
			}
			
			catch (Exception exc)
			{
				Debug.WriteLine("Unable to make game." + exc.Message);
				ModelState.AddModelError("", "Couldn't make game. " + exc.Message);
				return View(game); //foutieve view teruggeven 
			}
		}

		[HttpPost]
		[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Quizmaster")]
		public async Task<IActionResult> AddQuestion(Question q)
		{
			try
			{ // Done nog zonder input validatie: Add insert logic here 
				if (!ModelState.IsValid) 
				{ 
					throw new Exception("Validation Error"); 
				}

				Game g = await _gamesRepo.GetGameForIdAsync(q.GameId);

				if (g == null)
					return NotFound();  //404

				Question qresult = await _questionsRepo.Add(q);

				List<Question> questions = g.Questions.ToList();

				if (g.QuestionCount == g.Questions.ToArray().Length)
				{
					g.TimeCreated = DateTime.Now;
					g.Active = true;
					g = await _gamesRepo.Update(g);
					IEnumerable<Game> allGames = await _gamesRepo.GetAllGamesAsync();
					return View("Games", allGames);
				}
				else
				{
					questions.Add(new Question()
					{
						Game = g,
						GameId = g.GameId,
						QuestionNumber = qresult.QuestionNumber + 1
					});

					g.Questions = questions;

					Question returnQuestion = g.Questions.Last();

					return View(returnQuestion);
				}
			} 
			catch (Exception exc) 
			{ 
				Debug.WriteLine("Unable to make question." + exc.Message); 
				ModelState.AddModelError("", "Couldn't add question. " + exc.Message); 
				return View(q); //foutieve view teruggeven 
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
