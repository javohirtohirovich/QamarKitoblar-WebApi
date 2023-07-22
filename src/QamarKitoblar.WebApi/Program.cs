using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Interfaces.Publishers;
using QamarKitoblar.DataAccess.Repositories.Geners;
using QamarKitoblar.DataAccess.Repositories.Publishers;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Geners;
using QamarKitoblar.Service.Interafaces.Publishers;
using QamarKitoblar.Service.Services.Common;
using QamarKitoblar.Service.Services.Geners;
using QamarKitoblar.Service.Services.Publishers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ->
builder.Services.AddScoped<IGenerRepository, GenerRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGenerService, GenerService>();
builder.Services.AddScoped<IPublisherRepository,PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

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
