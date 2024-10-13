using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using News.DataAccess;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Infrastructure;
using News.Mapping;
using News.Services.ServicesInterface;
using News.Services;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<GoogleAuthOptions>(builder.Configuration.GetSection(nameof(GoogleAuthOptions)));
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Укажите ваш фронтенд-URI
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var rsa = RSA.Create();

    var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
    rsa.ImportFromPem(jwtOptions.PublicKey.ToCharArray());

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new RsaSecurityKey(rsa),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = string.Empty;
connection = builder.Configuration.GetConnectionString("MySQLServer");

builder.Services.AddDbContext<DbContext, NewsDb>(options =>
    options.UseSqlServer(connection));

builder.Services.AddHttpClient<GoogleAuthService>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommentRepo, CommentRepo>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IPasswordRepo, PasswordRepo>();
builder.Services.AddTransient<ITokenRepo, TokenRepo>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddTransient<ITokenHelper, TokenHelper>();
builder.Services.AddTransient<IPasswordEncryptionHelper, PasswordEncryptionHelper>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IArticleRepo, ArticleRepo>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IPublisherRepo, PublisherRepo>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<ITagRepo, TagRepo>();
builder.Services.AddTransient<IGoogleAuthService, GoogleAuthService>();





builder.Services.AddAutoMapper(typeof(NewsMappingProfile));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();