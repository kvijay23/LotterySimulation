using LotterySimulation.Core.Interfaces;

namespace LotterySimulation.Core.Services
{
    public class PrizeCalculator : IPrizeCalculator
    {
        public (int GrandPrize, int SecondPrizeTotal, int ThirdPrizeTotal) CalculatePrizes(int totalRevenue)
        {
            int grandPrize = totalRevenue / 2;
            int secondPrizeTotal = (totalRevenue * 30) / 100;
            int thirdPrizeTotal = (totalRevenue * 10) / 100;
            return (grandPrize, secondPrizeTotal, thirdPrizeTotal);
        }
    }
}
