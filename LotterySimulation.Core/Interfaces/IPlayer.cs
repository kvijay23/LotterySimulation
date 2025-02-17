namespace LotterySimulation.Core.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        int Balance { get; }
        List<int> Tickets { get; }
        void PurchaseTickets(int number, ref int ticketCounter);
    }
}
