using CallScheduler;
using CallScheduler.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<CallerService>();
        services.AddSingleton<Worker>();
        services.AddHostedService(
            provider => provider.GetRequiredService<Worker>());
    })
    .Build();

await host.RunAsync();
