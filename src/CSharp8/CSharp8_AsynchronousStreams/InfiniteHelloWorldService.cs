public class InfiniteHelloWorldService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} Hello World!!! -> Seems that data is fetched from DB asynchronously =) Because you see this message during processor processing Animal item.");
            await Task.Delay(10, stoppingToken);
        }
    }
}