var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
