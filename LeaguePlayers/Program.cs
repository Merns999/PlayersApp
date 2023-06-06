using LeaguePlayers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//builder.Services.AddDbContext<LeaguePlayersContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LeaguePlayersContext") ?? throw new InvalidOperationException("Connection string 'LeaguePlayersContext' not found.")));

//builder.Services.AddDbContext<LeaguePlayersDbContext>(options =>
//    options.UseSqlServer("leagueplayersdbconnectionstring", sqlOptions =>
//        sqlOptions.EnableRetryOnFailure()));
builder.Services.AddDbContext<LeaguePlayersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LeaguePlayersContext")));


builder.Services.AddControllers();

var app = builder.Build();

//builder.Services.AddDbContext<LeaguePlayersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("leagueplayersdbconnectionstring")));
//builder.Services.AddDbContext<LeaguePlayersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("leagueplayersdbconnectionstring")));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
