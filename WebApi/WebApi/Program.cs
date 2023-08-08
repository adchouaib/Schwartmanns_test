using Application;
using Infrastructure;
using WebApi.Extensions;
using Infrastructure.MigrationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterConfigurationManager();
builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureCorsPolicy();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase().Run();
app.Run();

