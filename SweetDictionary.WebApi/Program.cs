using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository;
using SweetDictionary.Repository.Categories.Repositories.Abstract;
using SweetDictionary.Repository.Categories.Repositories.Concrete;
using SweetDictionary.Repository.Comments.Repositories.Abstract;
using SweetDictionary.Repository.Comments.Repositories.Concrete;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Service;
using SweetDictionary.Service.Categories.Rules;
using SweetDictionary.Service.Categories.Services.Abstracts;
using SweetDictionary.Service.Categories.Services.Concretes;
using SweetDictionary.Service.Comments.Rules;
using SweetDictionary.Service.Comments.Services.Abstracts;
using SweetDictionary.Service.Comments.Services.Concretes;

using SweetDictionary.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRepositoryDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();
builder.Services.AddScoped<ICategoryService, EfCategoryService>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<CategoryBusinessRules, CategoryBusinessRules>();
builder.Services.AddScoped<ICommentService, EfCommentService>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<CommentBusinessRules, CommentBusinessRules>();

builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));




builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireDigit = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BaseDbContext>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOptions.SecurityKey)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
