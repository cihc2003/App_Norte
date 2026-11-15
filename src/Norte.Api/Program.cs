using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Norte.Abstracciones.Servicios;
using Norte.Api.Configuracion.Modulos;
using Norte.Api.Filtros;
using Norte.Api.Servicios;
using Norte.DA.Contexto;

var builder = WebApplication.CreateBuilder(args);

// --- Controladores con filtro global de excepciones de dominio ---
builder.Services.AddControllers(opciones => opciones.Filters.Add<ExcepcionesFiltro>())
    // Los enums viajan como texto ("Gasto"), no como número.
    .AddJsonOptions(opciones => opciones.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddOpenApi();

// --- Base de datos: PostgreSQL con EF Core + Npgsql ---
// Se registra la fábrica de contextos: permite inyectar NorteDbContext por solicitud y,
// además, crear un contexto por tarea cuando haya consultas en paralelo (el DbContext no
// es seguro para hilos).
var cadenaConexion = builder.Configuration.GetConnectionString("Norte")
    ?? throw new InvalidOperationException(
        "Falta ConnectionStrings:Norte. Configúrela con dotnet user-secrets (ver README).");
builder.Services.AddDbContextFactory<NorteDbContext>(opciones => opciones.UseNpgsql(cadenaConexion));

// --- Autenticación JWT ---
var claveJwt = builder.Configuration["Jwt:Clave"]
    ?? throw new InvalidOperationException(
        "Falta Jwt:Clave. Configúrela con dotnet user-secrets (ver README).");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opciones =>
    {
        opciones.MapInboundClaims = false;
        opciones.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Emisor"],
            ValidAudience = builder.Configuration["Jwt:Audiencia"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveJwt))
        };
    });
builder.Services.AddAuthorization();

// --- CORS para el servidor de desarrollo de Vite (riesgo 8) ---
builder.Services.AddCors(opciones => opciones.AddPolicy("SPA", politica =>
    politica.WithOrigins(builder.Configuration["Cors:OrigenSpa"] ?? "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUsuarioActual, UsuarioActual>();

// --- Registro de dependencias por módulo ---
// Cada responsable registra SUS clases en su propio archivo de Configuracion/Modulos,
// así nadie edita este Program.cs y se evitan conflictos de merge.
builder.Services.AgregarModuloCategorias();
builder.Services.AgregarModuloAutenticacion();
builder.Services.AgregarModuloMovimientos();
builder.Services.AgregarModuloDeudas();
builder.Services.AgregarModuloPresupuestos();
builder.Services.AgregarModuloMetas();
builder.Services.AgregarModuloReportes();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opciones => opciones.SwaggerEndpoint("/openapi/v1.json", "Norte API v1"));
}

app.UseHttpsRedirection();
app.UseCors("SPA");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Permite usar WebApplicationFactory<Program> en pruebas de integración.
public partial class Program { }
