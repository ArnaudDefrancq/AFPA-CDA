
using Microsoft.EntityFrameworkCore;
using NewApi.Models.Services;
using NewApi.Models;

namespace NewApi
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

			builder.Services.AddDbContext<EntrepriseDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
			builder.Services.AddTransient<EmployesService>();
			builder.Services.AddTransient<VoitureFonctionsService>();
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