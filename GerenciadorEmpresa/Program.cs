using Gerenciador.Domain.Interfaces;
using Gerenciador.InfraStructure.Context;
using Gerenciador.InfraStructure.Repository;
using Gerenciador.Service.Implementation;
using Gerenciador.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GerenciadorEmpresaDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApiRestConnectionString")));

#region Registrando a injeção de dependência das classes de serviço

builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();

#endregion

#region Registrando a injeção de dependência dos repositórios

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
