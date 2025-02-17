using LotterySimulation.Core.Interfaces;
using LotterySimulation.Domain;

namespace LotterySimulation.Core.Services
{
    public class LotteryGame : ILotteryGame
    {
        private readonly List<Player> players = new();
        private readonly Dictionary<int, Player> ticketOwners = new();
        private int ticketCounter = 1;
        private readonly INotificationService notificationService;

        private const double GrandPrizePercentage = 0.5;
        private const double SecondTierPercentage = 0.3;
        private const double ThirdTierPercentage = 0.1;
        private const double SecondTierWinnersPercentage = 0.1;
        private const double ThirdTierWinnersPercentage = 0.2;

        public LotteryGame(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public void Run()
        {
            notificationService.ShowWelcomeMessage();
            SetupPlayers();
            AssignTickets();
            DrawWinners();
        }

        private void SetupPlayers()
        {
            Console.Write("How many tickets would you like to purchase? ");
            if (!int.TryParse(Console.ReadLine(), out int playerTickets)) playerTickets = 1;
            playerTickets = Math.Clamp(playerTickets, 1, (int)TicketPricing.MaxTicketsPerPlayer);

            var humanPlayer = new Player("Player 1");
            players.Add(humanPlayer);
            humanPlayer.PurchaseTickets(playerTickets, ref ticketCounter);

            var rnd = new Random();
            int totalPlayers = rnd.Next((int)TicketPricing.MinPlayers - 1, (int)TicketPricing.MaxPlayers - 1);

            for (int i = 2; i <= totalPlayers + 1; i++)
            {
                var cpuPlayer = new Player($"Player {i}");
                players.Add(cpuPlayer);
                int cpuTickets = rnd.Next(1, (int)TicketPricing.MaxTicketsPerPlayer + 1);
                cpuPlayer.PurchaseTickets(cpuTickets, ref ticketCounter);
            }

            notificationService.ShowTicketPurchaseInfo(totalPlayers);
        }

        private void AssignTickets()
        {
            foreach (var player in players)
            {
                foreach (var ticket in player.Tickets)
                {
                    ticketOwners[ticket] = player;
                }
            }
        }

        private void DrawWinners()
        {
            var rnd = new Random();
            int totalRevenue = ticketOwners.Count * (int)TicketPricing.TicketCost;
            List<int> allTickets = ticketOwners.Keys.ToList();

            string drawResults = "";

            // Grand Prize
            int grandPrizeTicket = allTickets[rnd.Next(allTickets.Count)];
            int grandPrizeAmount = (int)(totalRevenue * GrandPrizePercentage);
            Player grandWinner = ticketOwners[grandPrizeTicket];
            drawResults += $" Grand Prize: {grandWinner.Name} wins ${grandPrizeAmount}!\n";
            allTickets.Remove(grandPrizeTicket);

            // Second Tier
            drawResults += DistributePrize(allTickets, SecondTierWinnersPercentage, SecondTierPercentage, " Second Tier Prize");

            // Third Tier
            drawResults += DistributePrize(allTickets, ThirdTierWinnersPercentage, ThirdTierPercentage, " Third Tier Prize");

            notificationService.ShowDrawResults(drawResults);

            // House Profit
            int houseProfit = totalRevenue - (grandPrizeAmount + (int)(totalRevenue * SecondTierPercentage) + (int)(totalRevenue * ThirdTierPercentage));
            notificationService.ShowHouseRevenue(houseProfit);
        }

        private string DistributePrize(List<int> availableTickets, double percentTickets, double prizeShare, string tier)
        {
            var rnd = new Random();
            int winnersCount = Math.Max(1, (int)Math.Round(availableTickets.Count * percentTickets));
            int totalPrize = (int)(ticketOwners.Count * (int)TicketPricing.TicketCost * prizeShare);
            string result = "";

            if (winnersCount > availableTickets.Count)
            {
                winnersCount = availableTickets.Count;
            }

            if (winnersCount > 0)
            {
                List<int> winningTickets = availableTickets.OrderBy(_ => rnd.Next()).Take(winnersCount).ToList();
                int individualPrize = winnersCount > 0 ? Math.Max(1, totalPrize / winnersCount) : 0;

                result += $"{tier}:\n";
                foreach (var ticket in winningTickets)
                {
                    Player winner = ticketOwners[ticket];
                    result += $" - {winner.Name} wins ${individualPrize}\n";
                    availableTickets.Remove(ticket);
                }
            }
            else
            {
                result += $"{tier}:\n - No winners\n";
            }
            return result;
        }
    }
}
