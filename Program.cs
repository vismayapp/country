var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add this before builder.Build()
builder.Services.AddHttpClient<CountriesNowService>();
builder.Services.AddEndpointsApiExplorer(); // Add this before building
builder.Services.AddSwaggerGen();
var app = builder.Build();
builder.Services.AddEndpointsApiExplorer(); // Essential for Swagger

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
