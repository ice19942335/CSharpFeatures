using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("DummyDb");
});

builder.Services.AddHostedService<AsynchronousStreamService>();
builder.Services.AddHostedService<InfiniteHelloWorldService>();
builder.Services.AddHostedService<DbSeedService>();

var app = builder.Build();

// using var serviceScope = app.Services.CreateScope();
// var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
// context.Database.EnsureCreated();
// await SeedContext();
//
// async Task SeedContext()
// {
//     const int seedCount = 10;
//     Console.WriteLine("Seeding context...");
//     for (int i = 1; i < seedCount; i++)
//     {
//         context.Animals.Add(new Animal
//         {
//             Name = $"Name_{i}",
//             Birthday = DateTime.Now,
//         });
//         await Task.Delay(10);
//     }
//         
//     await context.SaveChangesAsync();
// }

app.Run();