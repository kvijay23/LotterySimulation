using LotterySimulation.Core.Interfaces;
using LotterySimulation.Core.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<INotificationService, ConsoleNotificationService>()
    .AddSingleton<ILotteryGame>(provider => new LotteryGame(provider.GetService<INotificationService>()))
    .BuildServiceProvider();

var notificationService = serviceProvider.GetService<INotificationService>();
var game = serviceProvider.GetService<ILotteryGame>();
game.Run();
