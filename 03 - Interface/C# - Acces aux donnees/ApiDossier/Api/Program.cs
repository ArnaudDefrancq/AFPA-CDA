
using Api.Models.Data;
using Api.Models.Data.Services;
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

			builder.Services.AddControllers().AddNewtonsoftJson();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<MyDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

			builder.Services.AddTransient<PersonnesServices>();
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