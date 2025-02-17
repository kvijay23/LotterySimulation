namespace LotterySimulation.Core.Interfaces
{
    public interface IPrizeCalculator
    {
        (int GrandPrize, int SecondPrizeTotal, int ThirdPrizeTotal) CalculatePrizes(int totalRevenue);
    }
}
