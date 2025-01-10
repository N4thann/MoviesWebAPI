using Microsoft.IdentityModel.Tokens;
using MoviesAPI.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();//Configuração do Middleware de Exceção, apenas no ambiente Developer
}

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "AuthAPI",
            ValidAudience = "MoviesAPI",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey123"))
        };
    });

app.UseHttpsRedirection();

// Adiciona o middleware de autenticação
app.UseAuthentication(); // Este middleware verifica o token JWT nas requisições

app.UseAuthorization();

app.MapControllers();

app.Run();
