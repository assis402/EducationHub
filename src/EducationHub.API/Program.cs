using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Services;
using EducationHub.Infrastructure;
using EducationHub.Infrastructure.Helpers;
using EducationHub.Infrastructure.Repositories;
using EducationHub.Shared.Environment;
using EducationHub.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
    DotEnvLoader.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationHub API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var key = Settings.Secret.ConvertToASCII();
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            //TODO conferir as validations
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddSingleton<EducationHubContextDb>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ICourseSectionService, CourseSectionService>();
builder.Services.AddTransient<IUserActionEmailHistoryService, UserActionEmailHistoryService>();
builder.Services.AddTransient<IBaseRepository<Course>, BaseRepository<Course>>();
builder.Services.AddTransient<IBaseRepository<CourseSection>, BaseRepository<CourseSection>>();
builder.Services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddTransient<IBaseRepository<UserActionEmailHistory>, BaseRepository<UserActionEmailHistory>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();