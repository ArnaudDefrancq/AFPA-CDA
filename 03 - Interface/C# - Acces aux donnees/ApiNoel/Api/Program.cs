
using Api.Models;
using Api.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddControllers().AddNewtonsoftJson();


			builder.Services.AddDbContext<NoelDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
			builder.Services.AddTransient<EnfantService>();
			builder.Services.AddTransient<CadeauService>();
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}



