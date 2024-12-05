
using Event.Core.Interface;
using Event.Core.Repositories;
using Event.Core.Services;
using Event.Data.Repositories;
using Event.Service;
using EventCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDataContext, DataContext>();

// רישום הרפוזיטוריז
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// רישום השירותים
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()  // מאפשר לכל דומיין לשלוח בקשות
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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
