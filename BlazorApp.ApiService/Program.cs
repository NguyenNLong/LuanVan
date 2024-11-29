using BlazorApp.BL.Repositories;
using BlazorApp.BL.Services;
using BlazorApp.Database.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true; // Nếu muốn format JSON đẹp hơn (có thụt dòng)
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            Array.Empty<string>()
        }
    });
});



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var secret = builder.Configuration.GetValue<string>("Jwt:Secret");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "LuanVan",
        ValidAudience = "LuanVan",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();



// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();

app.Run();
