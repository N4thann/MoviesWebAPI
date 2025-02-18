using Microsoft.IdentityModel.Tokens;
using MoviesAPI.Extensions;
using MoviesAPI.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));//aplicando filtro de exce��o global n�o tratada
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApiLoggingFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();//Configura��o do Middleware de Exce��o, apenas no ambiente Developer
}

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "AuthAPI",
//            ValidAudience = "MoviesAPI",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey123"))
//        };
//    });

app.UseHttpsRedirection();

// Adiciona o middleware de autentica��o
app.UseAuthentication(); // Este middleware verifica o token JWT nas requisi��es

app.UseAuthorization();

app.MapControllers();

app.Run();
