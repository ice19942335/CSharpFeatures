using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

public class AsynchronousStreamService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();

        while (!stoppingToken.IsCancellationRequested)
        {
            var timespan = TimeSpan.FromSeconds(5);
            var cts = new CancellationTokenSource(delay: timespan);
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TestDbContext>();
            Console.WriteLine($"Total animals count: {context.Animals.Count(x => x.Id > 0)}");
            Console.WriteLine($"Processed Animals count BEFORE Run: {context.Animals.Count(x => x.Id > 0 && x.Processed)}");
            Console.WriteLine($"Unprocessed Animals count BEFORE Run: {context.Animals.Count(x => x.Id > 0 && !x.Processed)}");
            await Run(context, cts.Token);
            Console.WriteLine($"Processed Animals count AFTER Run: {context.Animals.Count(x => x.Id > 0 && x.Processed)}");
            Console.WriteLine($"Unprocessed Animals count AFTER Run: {context.Animals.Count(x => x.Id > 0 && !x.Processed)}");
            await Task.Delay(timespan, stoppingToken);
        }
    }

    private async Task Run(TestDbContext context, CancellationToken cancellationToken)
    {
        try
        {
            await foreach (var item in GetAnimalsStream(context, cancellationToken))
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}, Processing - {item}");
                item.Processed = true;
                await context.SaveChangesAsync(cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
            }
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Cancellation has been requested...");
        }
    }

    private IAsyncEnumerable<Animal> GetAnimalsStream(TestDbContext context, CancellationToken cancellationToken)
    {
        return context.Animals.Where(x => !x.Processed).AsAsyncEnumerable();

        // await foreach (var item in context.Animals.Where(x => !x.Processed).AsAsyncEnumerable().WithCancellation(cancellationToken))
        // {
        //     yield return item;
        // }

        /*
                           return context.Animals.FromSqlRaw($"""
                                                  SELECT * FROM dbo."Animals" WHERE "Processed" = 0
                                                  """).AsAsyncEnumerable();
        */

        //return context.Animals.Where(x => !x.Processed).AsAsyncEnumerable();
    }
}
