using Forno_OttoHx.Infra.Data;
using Forno_OttoHx.Infra.Repositorio;
using Forno_OttoHx.Infra.Repositorio.Interfaces;
using Forno_OttoHx.Servicos.Servicos;
using Forno_OttoHx.Servicos.Servicos.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OracleDbContext>(options =>
{
    var configuration = builder.Configuration.GetConnectionString("OracleConnection");
    options.UseOracle(configuration);

});

builder.Services.AddScoped<IFornoRepositorio, FornoRepositorio>();
builder.Services.AddScoped<IFornoServico, FornoServico>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
