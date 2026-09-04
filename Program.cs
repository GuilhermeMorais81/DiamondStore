using DiamondStore.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<DataContext>(name:"app.db");
var app = builder.Build();
app.MapHealthChecks("/health");
app.MapControllers();
app.Run();
