using MassTransit;
using QueueFinal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(MassTransitCfg =>
{
    MassTransitCfg.AddConsumer<MessageConsumer>(cfg =>
    {
        cfg.ConcurrentMessageLimit = 1;
    });

    MassTransitCfg.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

    MassTransitCfg.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

// builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
