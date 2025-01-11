public class DbSeedService(AppDbContext context) : BackgroundService
{
    private static readonly Random Random = new Random();
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();
        while (!stoppingToken.IsCancellationRequested)
        {
            context.Animals.Add(new Animal
            {
                Name = $"Random name {Random.Next(10000000)}",
                Birthday = DateTime.Now,
            });
            await context.SaveChangesAsync(stoppingToken);
            await Task.Delay(500, stoppingToken);
        }
    }
}