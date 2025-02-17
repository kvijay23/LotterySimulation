namespace LotterySimulation.Infrastructure
{
    public static class ConsoleInputHandler
    {
        public static int GetUserTicketInput(int max)
        {
            Console.WriteLine($"Enter number of tickets to buy (max {max}): ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > max)
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            return input;
        }
    }
}
