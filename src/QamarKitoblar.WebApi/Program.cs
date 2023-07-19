using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Repositories.Geners;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Geners;
using QamarKitoblar.Service.Services.Common;
using QamarKitoblar.Service.Services.Geners;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ->
builder.Services.AddScoped<IGenerRepository, GenerRepository>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IGenerService, GenerService>();

// ->

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
