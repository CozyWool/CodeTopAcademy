using LibraryWebApplication;

CreateHostBuilder(args).Build().Run();
return;

IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());