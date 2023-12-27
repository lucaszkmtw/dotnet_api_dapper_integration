using API_Pagos;
using BussinessLogic.API_Pagos.Services;
using DataAccess.Infrastructure;
using DataAccess.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();


var startup = new Startup(configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkFlow-API 6", Version = "v2 JWT" });

    //Boton Authorize (Swagger)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
           new string[] {}
       }
    });
});

var logger = new LoggerConfiguration()
  .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // To filter out Microsoft logs
        .WriteTo.File($"logs\\log-{DateTime.Now:yyyy-MM-dd}.txt", rollingInterval: RollingInterval.Year)
        .CreateLogger();


// Obtengo la cadena de conexion
//var connectionString = configuration.GetConnectionString("OracleConnection");
//var AllowdIps = configuration.GetSection("AllowedIps").Get<string[]>();
// Inyecto la cadena de conexion
//builder.Services.AddOracle<DESA2_WF_Context>(connectionString);
//builder.Services.AddOracle<SEGU_USUARIO_Context>(connectionString);


// Inyectamos los servicios (necesario para que se reconozcan dentro de la API)
//builder.Services.AddScoped<ActividadesService>();
//builder.Services.AddScoped<UsuarioActividadService>();
builder.Services.AddScoped<IRepositoryAccess, RepositoryAccess>();
builder.Services.AddScoped<LoginService>();
//builder.Services.AddScoped<PagosSerivce>();
//builder.Services.AddScoped<TesoreriaService>();
//builder.Services.AddScoped<RcfService>();

//builder.Services.AddScoped<GenericService>();
//builder.Services.AddScoped<UsuarioService>();
// Agrego Autenticacion por JWT
string cositas = configuration["JWT:key"].ToString();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"].ToString())),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


//builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
//{
//    builder.WithOrigins(AllowdIps).AllowAnyMethod().AllowAnyHeader();
//}));
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();
startup.Configure(app, builder.Environment);
