namespace LotterySimulation.Domain
{
    public class Player
    {
        public string Name { get; }
        public int Balance { get; private set; } = 10;
        public List<int> Tickets { get; } = new();

        public Player(string name)
        {
            Name = name;
        }

        public void PurchaseTickets(int number, ref int ticketCounter)
        {
            int affordableTickets = Math.Min(number, Balance);
            Balance -= affordableTickets;

            for (int i = 0; i < affordableTickets; i++)
            {
                Tickets.Add(ticketCounter++);
            }
        }
    }
}
