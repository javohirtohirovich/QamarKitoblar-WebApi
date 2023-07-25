using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Interfaces.Publishers;
using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.DataAccess.Repositories.Geners;
using QamarKitoblar.DataAccess.Repositories.Publishers;
using QamarKitoblar.DataAccess.Repositories.Users;
using QamarKitoblar.Service.Interafaces.Auth;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Geners;
using QamarKitoblar.Service.Interafaces.Notifcations;
using QamarKitoblar.Service.Interafaces.Publishers;
using QamarKitoblar.Service.Interafaces.Users;
using QamarKitoblar.Service.Services.Auth;
using QamarKitoblar.Service.Services.Common;
using QamarKitoblar.Service.Services.Geners;
using QamarKitoblar.Service.Services.Notifcations;
using QamarKitoblar.Service.Services.Publishers;
using QamarKitoblar.Service.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
// ->
builder.Services.AddScoped<IGenerRepository, GenerRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGenerService, GenerService>();
builder.Services.AddScoped<IPublisherRepository,PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<ISmsSender,SmsSender>();

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
