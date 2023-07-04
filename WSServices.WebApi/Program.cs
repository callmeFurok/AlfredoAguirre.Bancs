using Microsoft.EntityFrameworkCore;
using WSApplication.Interface;
using WSApplication.Main;
using WSDomain.Core;
using WSDomain.Interface;
using WSInfraesctructure.Repository;
using WSInfraestructure.Data;
using WSInfraestructure.Interface;
using WSTransversal.Mapp;

var builder = WebApplication.CreateBuilder(args);

// Add default connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

#region Add Clients Services
builder.Services.AddScoped<IClientsApplication, ClientsApplication>();
builder.Services.AddScoped<IClientsDomain, ClientsDomain>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
#endregion

#region Add Accounts Services
builder.Services.AddScoped<IAccountsApplication, AccountsApplication>();
builder.Services.AddScoped<IAccountsDomain, AccountsDomain>();
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
#endregion

#region Add Transactions Services
builder.Services.AddScoped<ITransactionsApplication, TransactionsApplication>();
builder.Services.AddScoped<ITransactionsDomain, TransactionsDomain>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
#endregion

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