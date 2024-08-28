using Infrastructure.Contexts;
using Infrastructure.Handlers.Repositories;
using Infrastructure.Handlers.Services;
using Infrastructure.Handlers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("TransfermarktDatabase") ?? throw new InvalidOperationException("Connection string 'TransfermarktDatabase' not found");

builder.Services.AddDbContext<TransfermarktDataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<CompetitionRepository>();
builder.Services.AddScoped<ClubRepository>();
builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<ITransfermarktAPIService, TransfermarktAPIService>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<IClubService, ClubService>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var competitionService = scope.ServiceProvider.GetRequiredService<ICompetitionService>();

    if (!await competitionService.CheckIfCompetitionTableContainsAnyRecords())
    {
        var competitions = await competitionService.GetCompetitionsFromTransfermarktAPI();

        foreach (var competition in competitions)
        {
            await competitionService.CreateCompetition(competition);
        }
    }

    var clubService = scope.ServiceProvider.GetRequiredService<IClubService>();

    if (!await clubService.CheckIfClubTableContainsAnyRecords())
    {
        var allCompetitionClubsDictionaries = await clubService.GetClubsWithCompetitionIdFromTransfermarktAPI();

        foreach(var competitionClubDictionary in allCompetitionClubsDictionaries)
        {

            foreach (var club in competitionClubDictionary.Value)
            {
                await clubService.CreateClub(competitionClubDictionary.Key, club);
            }
        }


    }

}



app.Run();
