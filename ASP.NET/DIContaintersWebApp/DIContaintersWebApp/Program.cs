using DIContaintersWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ITimerService, TimerService>();

// builder.Services.AddTransient<ICounter, RandomCounter>();
// builder.Services.AddTransient<CounterService>();
builder.Services.AddScoped<ICounter, RandomCounter>();
builder.Services.AddScoped<CounterService>();

var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

// app.Run(async context =>
// {
//     var timerService = app.Services.GetService<ITimerService>();
//     var timerService2 = app.Services.GetService<ITimerService>();
//     string result = $"Timer1: {timerService.GetTime()}; Timer2: {timerService2.GetTime()}";
//     await context.Response.WriteAsync(result);
// });

app.Run();