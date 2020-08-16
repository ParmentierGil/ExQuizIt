using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExQuizIt.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExQuizIt.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//CreateHostBuilder(args).Build().Run(); //NIET LANGER DIRECT OPROEPEN 
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<ExQuizItDbContext>();
					context.Database.EnsureDeleted();  //verwijder (-> niet doen in productie) 
					context.Database.EnsureCreated(); //maakt db aan volgens entiteiten 
					context.Database.Migrate(); //voert migraties uit 
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "EnsureCreated: An error occurred creating the DB.");
				}
			}
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
