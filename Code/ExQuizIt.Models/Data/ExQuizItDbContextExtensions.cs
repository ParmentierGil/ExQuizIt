using ExQuizIt.Models.Repos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExQuizIt.Models.Data
{
	public class ExQuizItDbContextExtensions
	{
		public async static Task SeedRoles(RoleManager<IdentityRole> RoleMgr)
		{
			IdentityResult roleResult; string[] roleNames = { "Quizmaster", "Player"};
			foreach (var roleName in roleNames)
			{ //verhinderen dat continue dezelfde rollen worden toegvoegd. 
				var roleExist = await RoleMgr.RoleExistsAsync(roleName); 
				if (!roleExist) 
				{ 
					roleResult = await RoleMgr.CreateAsync(new IdentityRole(roleName)); 
				} 
			} 
		}

		public async static Task SeedUsers(UserManager<User> userMgr) 
		{
			var user = new Quizmaster()
			{
				Id = Guid.NewGuid().ToString(),
				Email = "johan.van@howest.be",
				UserName = "johan.van@howest.be",
				Displayname = "Quizmaster-Johan"
			};
			var userResult = await userMgr.CreateAsync(user, "Docent@1");
			var roleResult = await userMgr.AddToRoleAsync(user, "Quizmaster");
			// var claimResult = await userMgr.AddClaimAsync(user, new Claim("DocentWeb", "True"));
			if (!userResult.Succeeded || !roleResult.Succeeded)
			{
				throw new InvalidOperationException("Failed to build user and roles");
			}

			var user2 = new Player()
			{
				Id = Guid.NewGuid().ToString(),
				Email = "gp@howest.be",
				UserName = "gp@howest.be",
				Displayname = "Player-Gil"
			};
			var userResult2 = await userMgr.CreateAsync(user2, "Gil1515$");
			var roleResult2 = await userMgr.AddToRoleAsync(user2, "Player");

			if (!userResult2.Succeeded || !roleResult2.Succeeded)
			{
				throw new InvalidOperationException("Failed to build user and roles");
			}
		}

		public async static Task SeedGame1(IGamesRepo gamesRepo, IQuestionsRepo questionsRepo)
		{
			var game = new Game()
			{
				Difficulty = Game.DifficultyType.Easy,
				Subject = "Sport",
				TimeCreated = DateTime.Now,
				Active = true,
				QuestionCount = 10
			};
			game = await gamesRepo.Add(game);

			var q1 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "In welke stad vonden de laatste Olympische Zomerspelen plaats?",
				CorrectAnswer = "Rio de Janeiro",
				WrongAnswer1 = "Londen",
				WrongAnswer2 = "Tokyo",
				WrongAnswer3 = "PyeongChang"
			};
			var questionResult = await questionsRepo.Add(q1);

			var q2 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Op hoeveel punten win je een tafeltennis set?",
				CorrectAnswer = "11",
				WrongAnswer1 = "21",
				WrongAnswer2 = "10",
				WrongAnswer3 = "25"
			};
			var questionResult2 = await questionsRepo.Add(q2);

			var q3 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoeveel spelers staan er op het veld bij voetbal?",
				CorrectAnswer = "22",
				WrongAnswer1 = "10",
				WrongAnswer2 = "11",
				WrongAnswer3 = "12"
			};
			var questionResult3 = await questionsRepo.Add(q3);

			var q4 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat was de laatste Belgische F1-chauffeur?",
				CorrectAnswer = "Stoffel Vandoorne",
				WrongAnswer1 = "Max Verstappen",
				WrongAnswer2 = "Jerome D'Ambrosio",
				WrongAnswer3 = "Nico Hulkenberg"
			};
			var questionResult4 = await questionsRepo.Add(q4);

			var q5 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "In welke discipline is het wereldrecord 18.29m?",
				CorrectAnswer = "Hinkstapspringen",
				WrongAnswer1 = "Hoogspringen",
				WrongAnswer2 = "Verspringen",
				WrongAnswer3 = "Polsstokspringen"
			};
			var questionResult5 = await questionsRepo.Add(q5);

			var q6 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat is laatste winnaar van de Tour de France (2019)?",
				CorrectAnswer = "Bernal",
				WrongAnswer1 = "Froome",
				WrongAnswer2 = "Sagan",
				WrongAnswer3 = "Wiggins"
			};
			var questionResult6 = await questionsRepo.Add(q6);

			var q7 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat is de maximum score bij een spelletje bowling?",
				CorrectAnswer = "300",
				WrongAnswer1 = "200",
				WrongAnswer2 = "500",
				WrongAnswer3 = "450"
			};
			var questionResult7 = await questionsRepo.Add(q7);

			var q8 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat is het maximum aantal punten met 1 pijltje in vogelpik?",
				CorrectAnswer = "60",
				WrongAnswer1 = "50",
				WrongAnswer2 = "100",
				WrongAnswer3 = "75"
			};
			var questionResult8 = await questionsRepo.Add(q8);

			var q9 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wie smijt er de bal meestal in American Football?",
				CorrectAnswer = "Quarterback",
				WrongAnswer1 = "Wingmen",
				WrongAnswer2 = "Lineback",
				WrongAnswer3 = "Center"
			};
			var questionResult9 = await questionsRepo.Add(q9);

			var q10 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoe lang duurt een quarter in de NBA?",
				CorrectAnswer = "12min",
				WrongAnswer1 = "10min",
				WrongAnswer2 = "15min",
				WrongAnswer3 = "6min"
			};
			var questionResult10 = await questionsRepo.Add(q10);

		}

		public async static Task SeedGame2(IGamesRepo gamesRepo, IQuestionsRepo questionsRepo)
		{
			var game = new Game()
			{
				Difficulty = Game.DifficultyType.Hard,
				Subject = "General Trivia",
				TimeCreated = DateTime.Now,
				Active = true,
				QuestionCount = 10
			};
			game = await gamesRepo.Add(game);

			var q1 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoeveel vingers hebben de Simpsons?",
				CorrectAnswer = "40",
				WrongAnswer1 = "5",
				WrongAnswer2 = "8",
				WrongAnswer3 = "10"
			};
			var questionResult = await questionsRepo.Add(q1);

			var q2 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat is het tweede grootste continent van de wereld?",
				CorrectAnswer = "Afrika",
				WrongAnswer1 = "Noord-Amerika",
				WrongAnswer2 = "Zuid-Amerika",
				WrongAnswer3 = "Europa"
			};
			var questionResult2 = await questionsRepo.Add(q2);

			var q3 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "In welke stad is er een bekende anarchistische wijk?",
				CorrectAnswer = "Kopenhagen",
				WrongAnswer1 = "Seattle",
				WrongAnswer2 = "Skopje",
				WrongAnswer3 = "Hasselt"
			};
			var questionResult3 = await questionsRepo.Add(q3);

			var q4 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoeveel botten heeft een mens?",
				CorrectAnswer = "205",
				WrongAnswer1 = "206",
				WrongAnswer2 = "197",
				WrongAnswer3 = "213"
			};
			var questionResult4 = await questionsRepo.Add(q4);

			var q5 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Welk land is de grootste exporteur van aardappelen?",
				CorrectAnswer = "China",
				WrongAnswer1 = "V.S.",
				WrongAnswer2 = "Duitsland",
				WrongAnswer3 = "Argentinië"
			};
			var questionResult5 = await questionsRepo.Add(q5);

			var q6 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "In welk jaar was de aanslag op Pearl Harbor?",
				CorrectAnswer = "1941",
				WrongAnswer1 = "1942",
				WrongAnswer2 = "1939",
				WrongAnswer3 = "1940"
			};
			var questionResult6 = await questionsRepo.Add(q6);

			var q7 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Welke van de volgende apps staat niet op de beurs?",
				CorrectAnswer = "Telegram",
				WrongAnswer1 = "Slack",
				WrongAnswer2 = "Snapchat",
				WrongAnswer3 = "Pinterest"
			};
			var questionResult7 = await questionsRepo.Add(q7);

			var q8 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoeveel Star Wars films zijn er?",
				CorrectAnswer = "9",
				WrongAnswer1 = "11",
				WrongAnswer2 = "8",
				WrongAnswer3 = "10"
			};
			var questionResult8 = await questionsRepo.Add(q8);

			var q9 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Hoeveel kinderen heeft Filip van België?",
				CorrectAnswer = "4",
				WrongAnswer1 = "5",
				WrongAnswer2 = "3",
				WrongAnswer3 = "2"
			};
			var questionResult9 = await questionsRepo.Add(q9);

			var q10 = new Question()
			{
				Game = game,
				GameId = game.GameId,
				QuestionText = "Wat is de hoogste berg van Europa?",
				CorrectAnswer = "Elbroes",
				WrongAnswer1 = "Mont Blanc",
				WrongAnswer2 = "Kemmelberg",
				WrongAnswer3 = "Dufourspitze"
			};
			var questionResult10 = await questionsRepo.Add(q10);

		}
	}
}
