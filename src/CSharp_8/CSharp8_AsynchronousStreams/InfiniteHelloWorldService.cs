public class InfiniteHelloWorldService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} Hello World! -> Seems this background service doesn't block the stream!");
            await Task.Delay(250, stoppingToken);
        }
    }
}