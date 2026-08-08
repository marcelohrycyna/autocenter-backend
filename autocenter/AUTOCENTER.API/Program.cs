using AUTOCENTER.CrosssCutting.DependenciesApp;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // HTTP na porta 8080
});

// Add services to the container.

builder.Services.AddControllers();
// Configurar CORS para aceitar qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Opcional: mantém AddOpenApi para integrar com Microsoft.AspNetCore.OpenApi se necessário
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<AUTOCENTER.Infra.Repositories.Interfaces.IUnitOfWork, AUTOCENTER.Infra.Repositories.UnitOfWork>();
var app = builder.Build();

// Habilita CORS globalmente com a política "AllowAll"
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Expor o JSON do OpenAPI e o Swagger UI em Development
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
