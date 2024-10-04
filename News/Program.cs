using Microsoft.EntityFrameworkCore;
using News.DataAccess;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Infrastructure;
using News.Mapping;
using News.Services;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = string.Empty;
connection = builder.Configuration.GetConnectionString("MySQLServer");

builder.Services.AddDbContext<DbContext, NewsDb>(options =>
    options.UseSqlServer(connection));

builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<ICommentRepo, CommentRepo>();
builder.Services.AddTransient<IPasswordEncryptionHelper, PasswordEncryptionHelper>();
builder.Services.AddTransient<UserEntityPasswordResolver>();



builder.Services.AddAutoMapper(typeof(NewsMappingProfile));

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