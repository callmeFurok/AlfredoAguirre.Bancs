using AA.Bancs.Application.Interface;
using AA.Bancs.Application.Main;
using AA.Bancs.Domain.Core;
using AA.Bancs.Domain.Interface;
using AA.Bancs.Infraesctructure.Repository;
using AA.Bancs.Infraestructure.Data;
using AA.Bancs.Infraestructure.Interface;
using AA.Bancs.Transversal.Mapp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add default connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

// Add services to the container.
builder.Services.AddScoped<IClientsApplication, ClientsApplication>();
builder.Services.AddScoped<IClientsDomain, ClientsDomain>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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