using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ExQuizIt.Models;
using ExQuizIt.Models.Data;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using ExQuizIt.Models.Repos;

namespace ExQuizIt.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ExQuizItDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddControllersWithViews();

			services.AddScoped<IGamesRepo, GamesRepo>();
			services.AddScoped<IQuestionsRepo, QuestionsRepo>();
			services.AddScoped<IGamePlayersRepo, GamePlayersRepo>();
			services.AddScoped<IPlayersRepo, PlayersRepo>();
			services.AddScoped<IQuizmastersRepo, QuizmastersRepo>();

			services.AddRazorPages();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.Name = "LoginCookie";
					options.LoginPath = "/Identity/Account/Login"; //This should login page path
					options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				});

			services.AddAuthorization(options =>
			{
				// This says, that all pages need AUTHORIZATION. But when a controller, 
				// for example the login controller in Login.cshtml.cs, is tagged with
				// [AllowAnonymous] then it is not in need of AUTHORIZATION. :)
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleMgr, UserManager<User> userMgr, IGamesRepo gamesRepo,
			IQuestionsRepo questionsRepo, IGamePlayersRepo gamePlayersRepo)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Games}");
				endpoints.MapRazorPages();
			});

			ExQuizItDbContextExtensions.SeedRoles(roleMgr).Wait();
			ExQuizItDbContextExtensions.SeedUsers(userMgr).Wait();
			ExQuizItDbContextExtensions.SeedGame1(gamesRepo, questionsRepo).Wait();
			ExQuizItDbContextExtensions.SeedGame2(gamesRepo, questionsRepo).Wait();
		}
	}
}
