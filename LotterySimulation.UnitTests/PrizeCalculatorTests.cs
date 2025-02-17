using LotterySimulation.Core.Services;


namespace LotterySimulation.UnitTests
{
    public class PrizeCalculatorTests
    {
        [Fact]
        public void CalculatePrizes_ShouldDistributePrizesCorrectly()
        {
            int totalRevenue = 100;

            var (grandPrize, secondPrizeTotal, thirdPrizeTotal) = new PrizeCalculator().CalculatePrizes(totalRevenue);

            Assert.Equal(50, grandPrize);
            Assert.Equal(30, secondPrizeTotal);
            Assert.Equal(10, thirdPrizeTotal);
        }

        [Fact]
        public void CalculatePrizes_ShouldHandleZeroRevenue()
        {
            int totalRevenue = 0;

            var (grandPrize, secondPrizeTotal, thirdPrizeTotal) = new PrizeCalculator().CalculatePrizes(totalRevenue);

            Assert.Equal(0, grandPrize);
            Assert.Equal(0, secondPrizeTotal);
            Assert.Equal(0, thirdPrizeTotal);
        }

        [Fact]
        public void CalculatePrizes_ShouldHandleNegativeRevenue()
        {
            int totalRevenue = -100;

            var (grandPrize, secondPrizeTotal, thirdPrizeTotal) = new PrizeCalculator().CalculatePrizes(totalRevenue);

            Assert.Equal(-50, grandPrize);
            Assert.Equal(-30, secondPrizeTotal);
            Assert.Equal(-10, thirdPrizeTotal);
        }
    }
}
