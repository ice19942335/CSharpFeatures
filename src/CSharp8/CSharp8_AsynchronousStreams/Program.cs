using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.UseInMemoryDatabase("DummyDb");
});

builder.Services.AddHostedService<AsynchronousStreamService>();
builder.Services.AddHostedService<InfiniteHelloWorldService>();
builder.Services.AddHostedService<DbSeedService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<TestDbContext>().Database.EnsureCreated();
    var ctx = scope.ServiceProvider.GetRequiredService<TestDbContext>();
    var result = ctx.Database.ExecuteSqlRaw($"""
                           TRUNCATE TABLE "Animals";
                           """);
    ctx.SaveChanges();
}

app.Run();