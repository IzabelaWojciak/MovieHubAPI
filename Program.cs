using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieHubClientMockChallenge.DBContexts;
using MovieHubClientMockChallenge.Repositories;
using MovieHubClientMockChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieHubContext>(options => options.UseSqlite("Name=MovieHubConnectionString"));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<PrincessTheatreService>();
builder.Services.AddScoped<HttpService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();