namespace LotterySimulation.Core.Interfaces
{
    public interface INotificationService
    {
        void ShowWelcomeMessage();
        void ShowTicketPurchaseInfo(int totalPlayers);
        void ShowDrawResults(string message);
        void ShowHouseRevenue(int houseProfit);
    }
}
