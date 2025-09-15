using Microsoft.Extensions.DependencyInjection;
using WeatherMonitoringAndReportingService.App;
using WeatherMonitoringAndReportingService.Logic.Readers;
using WeatherMonitoringAndReportingService.Logic.Services;
using WeatherMonitoringAndReportingService.Logic.Subjects;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddConfiguration()
            .AddServices();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        RunApp(serviceProvider);
    }

    public static void RunApp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var botSystem = scope.ServiceProvider.GetRequiredService<BotSystem>();
        var botLoader = scope.ServiceProvider.GetRequiredService<IBotLoader>();
        var readerService = scope.ServiceProvider.GetRequiredService<IReaderService>();
        botLoader.LoadBots(scope.ServiceProvider.GetRequiredService<IWeatherStation>());

        Console.WriteLine(Constants.Introduction);
        var userInput = InputParser.ParseInput();
        
        
        try
        {
            IFormatReader reader = FormatReader.ChooseReader(userInput);
            readerService.SetReader(reader);
            var readerData = readerService.ParseWeatherData(userInput);
            botSystem.ProcessInput(readerData);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine(Constants.InvalidInput);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}