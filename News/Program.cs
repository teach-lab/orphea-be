using Microsoft.EntityFrameworkCore;
using News.DataAccess;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Infrastructure;
using News.Mapping;
using News.Services.ServicesInterface;
using News.Services;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new DefaultContractResolver());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = string.Empty;
connection = builder.Configuration.GetConnectionString("MySQLServer");

builder.Services.AddDbContext<DbContext, NewsDb>(options =>
    options.UseSqlServer(connection));

builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommentRepo, CommentRepo>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IPasswordRepo, PasswordRepo>();
builder.Services.AddTransient<IPasswordEncryptionHelper, PasswordEncryptionHelper>();

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IArticleRepo, ArticleRepo>();

builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IPublisherRepo, PublisherRepo>();

builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<ITagRepo, TagRepo>();




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