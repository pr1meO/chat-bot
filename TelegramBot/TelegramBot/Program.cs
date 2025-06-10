using Microsoft.EntityFrameworkCore;
using TelegramBot.Shared.Constants;
using TelegramBot.Web.Infrastructure.Business.Services;
using TelegramBot.Web.Infrastructure.Configurations;
using TelegramBot.Web.Infrastructure.Extensions;
using TelegramBot.Web.Infrastructure.Middlewares;
using TelegramBot.Web.Infrastructure.Persistences;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString(Sections.DefaultConnection);
var options = builder.Configuration.GetSection(Sections.BotOptions);

builder.Services.AddRandom();
builder.Services.AddSpeech();
builder.Services.AddCommand();
builder.Services.AddDialogue();
builder.Services.AddSwaggerGen();
builder.Services.AddTelegramBot();
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddAdvertisement();
builder.Services.AddMachineLearning();
builder.Services.AddTextPreprocessing();
builder.Services.AddIntentRecognition();
builder.Services.AddResponseProviders();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFile(ConfigurationFiles.Dialogues);
builder.Configuration.AddJsonFile(ConfigurationFiles.BotConfig);

builder.Services.AddHostedService<WebhookHosted>();

builder.Services.Configure<BotOptions>(options);
builder.Services.Configure<BotConfig>(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.UseModelTraining();

await app.UseDialogueSeederAsync();

app.MapControllers();

app.Run();