using Serilog;

var logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.Debug()
                        .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Minute)
                        .MinimumLevel.Debug()
                        .CreateLogger();

//var endTime = DateTime.Now.AddMinutes(2);
//while(DateTime.Now < endTime)
//{
//    logger.Verbose("Verbose логированние");
//    logger.Debug("Debug логированние");
//    logger.Information("Information логированние");
//    logger.Warning("Warning логированние");
//    logger.Error("Error логированние");
//    logger.Fatal("Fatal логированние");
//}

var person = new Person(1,"Иван","Иванов");
var randomNumber = 42;

logger.Information( "Добавляем сообщение с информацией {@Person}, {RandomNumber}, {DateNow}",
    person,
    randomNumber,
    DateTime.Now);

logger.Information("Логгирование завершено");