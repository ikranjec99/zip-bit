using Newtonsoft.Json;
using ZipBit.API.Extensions;
using ZipBit.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add webhost config
builder.WebHost.Configure();

// Add host config
builder.Host.Configure();

var configuration = builder.Configuration;
var appSettings = configuration.Get<AppSettings>();

Console.WriteLine(JsonConvert.SerializeObject(appSettings, Formatting.Indented));

// Add services to the contianer.
builder.Services.AddServices(configuration, appSettings);

var app = builder.Build();

app.ConfigureMiddlewares();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();