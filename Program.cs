using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.UseCases;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Interfaces;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CRUD Teste tecnico Solfarma / Alex Liberato",
        Version = "v1"
    });

    options.EnableAnnotations(); // Habilita o uso de anotações no Swagger
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ClientUseCase>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Teste tecnico Solfarma / Alex Liberato");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
