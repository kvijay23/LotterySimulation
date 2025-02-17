using LotterySimulation.Domain;

namespace LotterySimulation.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_InitialBalance_ShouldBeTen()
        {
            var player = new Player("Test Player");

            int initialBalance = player.Balance;

            Assert.Equal(10, initialBalance);
        }

        [Fact]
        public void PurchaseTickets_ShouldDeductBalanceAndAddTickets()
        {
            var player = new Player("Test Player");
            int ticketCounter = 1;
            int ticketsToPurchase = 5;

            player.PurchaseTickets(ticketsToPurchase, ref ticketCounter);

            Assert.Equal(5, player.Balance);
            Assert.Equal(5, player.Tickets.Count);
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, player.Tickets);
        }

        [Fact]
        public void PurchaseTickets_ShouldNotExceedBalance()
        {
            var player = new Player("Test Player");
            int ticketCounter = 1;
            int ticketsToPurchase = 15;

            player.PurchaseTickets(ticketsToPurchase, ref ticketCounter);

            Assert.Equal(0, player.Balance);
            Assert.Equal(10, player.Tickets.Count);
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, player.Tickets);
        }

        [Fact]
        public void PurchaseTickets_ShouldNotAddTicketsIfBalanceIsZero()
        {
            var player = new Player("Test Player");
            int ticketCounter = 1;
            player.PurchaseTickets(10, ref ticketCounter);

            player.PurchaseTickets(5, ref ticketCounter);

            Assert.Equal(0, player.Balance);
            Assert.Equal(10, player.Tickets.Count);
        }
    }
}

