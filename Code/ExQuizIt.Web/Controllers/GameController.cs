using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExQuizIt.Models;
using ExQuizIt.Models.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExQuizIt.Web.Controllers
{
	public class GameController : Controller
	{

		private readonly ILogger<GameController> _logger;

		private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

		private IGamesRepo _gamesRepo;
		private IGamePlayersRepo _gamePlayersRepo;
		private IPlayersRepo _playersRepo;

		public GameController(ILogger<GameController> logger, IGamesRepo gamesRepo, IGamePlayersRepo gamePlayersRepo, IPlayersRepo playersRepo)
		{
			_logger = logger;
			_gamesRepo = gamesRepo;
			_gamePlayersRepo = gamePlayersRepo;
			_playersRepo = playersRepo;
		}

		[Authorize(AuthenticationSchemes = AuthSchemes, Roles= "Player")]
		public async Task<IActionResult> Play(GamePlayer gamePlayer)
		{
			_logger.LogInformation("User started playing.");

			if (gamePlayer.GameId == null || gamePlayer.PlayerId == null)
			{
				return BadRequest(); //400
			}
			Game g = await _gamesRepo.GetGameForIdAsync(gamePlayer.GameId);
			Player p = await _playersRepo.GetPlayerForIdAsync(gamePlayer.PlayerId);

			if (g == null || p == null)
			{
				return NotFound();  //404
			}
			
			gamePlayer.TimeStartPlaying = DateTime.Now;
			gamePlayer.GamePlayerId = Guid.NewGuid().ToString();
			gamePlayer.Player = p;
			gamePlayer.Game = g;

			gamePlayer = await _gamePlayersRepo.Add(gamePlayer);

			return View(gamePlayer);
		}

		[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Player")]
		public async Task<IActionResult> RightAnswer(GamePlayer gamePlayer)
		{
			_logger.LogInformation("User answered correct.");

			if (gamePlayer.GameId == null || gamePlayer.PlayerId == null)
			{
				return BadRequest(); //400
			}

			Game g = await _gamesRepo.GetGameForIdAsync(gamePlayer.GameId);
			Player p = await _playersRepo.GetPlayerForIdAsync(gamePlayer.PlayerId);

			if (g == null || p == null)
			{
				return NotFound();  //404
			}

			gamePlayer.Player = p;
			gamePlayer.Game = g;

			gamePlayer.Score += 100;
			gamePlayer.QuestionNumber += 1;

			ViewBag.Score = gamePlayer.Score;
			ViewBag.LastQuestionCorrect = true;


			if (gamePlayer.QuestionNumber < gamePlayer.Game.Questions.ToArray().Length)
			{
				return View("Play", gamePlayer);
			}
			else
			{
				gamePlayer = await _gamePlayersRepo.Update(gamePlayer);

				IEnumerable<GamePlayer> allPlayers = await _gamePlayersRepo.GetAllGamePlayersAsync();
				return View("Scoreboard", allPlayers);
			}
		}

		[Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Player")]
		public async Task<IActionResult> WrongAnswer(GamePlayer gamePlayer)
		{
			_logger.LogInformation("User answered wrong.");

			if (gamePlayer.GameId == null || gamePlayer.PlayerId == null)
			{
				return BadRequest(); //400
			}

			Game g = await _gamesRepo.GetGameForIdAsync(gamePlayer.GameId);
			Player p = await _playersRepo.GetPlayerForIdAsync(gamePlayer.PlayerId);

			if (g == null || p == null)
			{
				return NotFound();  //404
			}

			gamePlayer.Player = p;
			gamePlayer.Game = g;

			gamePlayer.Score -= 150;
			gamePlayer.QuestionNumber += 1;

			ViewBag.Score = gamePlayer.Score;
			ViewBag.LastQuestionCorrect = false;

			if (gamePlayer.QuestionNumber < gamePlayer.Game.Questions.ToArray().Length)
			{
				return View("Play", gamePlayer);
			}
			else
			{
				gamePlayer = await _gamePlayersRepo.Update(gamePlayer);

				IEnumerable<GamePlayer> allPlayers = await _gamePlayersRepo.GetAllGamePlayersAsync();
				return View("Scoreboard", allPlayers);
			}		
		}
	}
}
