using Stepforma_BR.Data;
using Microsoft.EntityFrameworkCore;
using Stepforma_BR.Models;
using Microsoft.AspNetCore.Identity;
using Stepforma_BR.Services;
using Stepforma_BR.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Buscando conex�es com banco de dados
var connectionString = builder.Configuration["ConnectionStrings:ContextConnection"];

builder.Services.AddDbContext<ContextStep>(opt =>
opt.UseLazyLoadingProxies().UseMySql(connectionString, 
ServerVersion.AutoDetect(connectionString)));


// Conex�o com Usuarios
var usuariosConnectionString = builder.Configuration["ConnectionStrings:UsuariosConnection"];

builder.Services.AddDbContext<UsuariosContext>(opt =>
{
    opt.UseMySql(usuariosConnectionString, 
        ServerVersion.AutoDetect(usuariosConnectionString));
});

builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuariosContext>()
    .AddDefaultTokenProviders();
/////////////////////////////////////////

// Adicionando autoriza��o de acesso
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("IdadeMinima", policy =>
    policy.AddRequirements(new IdadeMinima(14)));
});

// Adicionando o servi�o de autentica��o por JWT
builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new
    Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };

});

//Adicionando a inje��o da classe que gerencia as autoriza��es de idade
builder.Services.AddScoped<IAuthorizationHandler, IdadeAuthorization>();

// Adicionando o mapeamento de DTOs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Adicionando services
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<TokenService>();



// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
 O CORS (Cross-origin Resource Sharing) � um mecanismo utilizado pelos navegadores
para compartilhar recursos entre diferentes origens. O CORS � uma especifica��o do 
W3C e faz uso de headers do HTTP para informar aos navegadores se determinado recurso 
pode ser ou n�o acessado.
  */

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
