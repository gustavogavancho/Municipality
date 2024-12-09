using Microsoft.EntityFrameworkCore;
using Municipality.Api.Data;
using Municipality.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MunicipalityContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("MunicipalityDB")));
builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MunicipalityContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/{id:int}", async (int id, IMunicipalityRepository municipalityRepository) =>
{
    var municipality = await municipalityRepository.GetByIdAsync(id);
    if (municipality == null)
    {
        return Results.NotFound($"Municipio con id {id} no encontrado.");
    }
    return Results.Ok(municipality);
})
.WithName("GetMunicipioById")
.WithOpenApi();

app.Run();