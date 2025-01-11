# await foreach + IAsyncEnumerable
- AsynchronousStreamService -> Reading data from DB as asynchronous stream with `await foreach(...)` creates new `context` in every fixed amount of time to be able to fetch freshly added data.
- DbSeedService -> Constantly seeding DB.
- InfiniteHelloWorldService -> Simulates background service that does some job.

Run the application and you will see in console that all background services running independently and new entities from DB are consumed constantly as a asynchronous stream.<br />
More info here: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#await-foreach<br />