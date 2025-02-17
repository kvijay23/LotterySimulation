using LotterySimulation.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulation.Core.Services
{
    public class ConsoleNotificationService : INotificationService
    {
        public void ShowWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("══════════════════════════════════");
            Console.WriteLine(" Welcome to the Bede Lottery");
            Console.WriteLine("══════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine($"* Your digital balance: $10.00");
            Console.WriteLine($"* Ticket Price: ${(int)TicketPricing.TicketCost}.00 each\n");
        }

        public void ShowTicketPurchaseInfo(int totalPlayers)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{totalPlayers} other CPU players also purchased tickets\n");
            Console.ResetColor();
        }

        public void ShowDrawResults(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ticket Draw Results:");
            Console.WriteLine("═══════════════════════════");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowHouseRevenue(int houseProfit)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\nHouse Revenue: ${houseProfit}");
            Console.ResetColor();
        }
    }
}
