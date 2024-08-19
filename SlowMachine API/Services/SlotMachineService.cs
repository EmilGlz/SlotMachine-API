using SlowMachine_API.Config;
using SlowMachine_API.Contracts;
using SlowMachine_API.Models;
namespace SlowMachine_API.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        public IReelConfig Config { get; set; }

        public SlotMachineService()
        {
            Config = new ReelConfig();
        }

        public SpinResult SpinReels()
        {
            var stopPositions = Config.GetStopPositions();
            var screen = GetScreen(stopPositions);
            return new SpinResult(stopPositions, screen);
        }

        private string[][] GetScreen(int[] stopPositions)
        {
            string[][] screen = new string[3][];
            for (int i = 0; i < screen.Length; i++)
                screen[i] = new string[5];

            for (int i = 0; i < Config.ReelBands.Count; i++)
            {
                var visibleSymbols = Config.ReelBands[i].GetVisibleSymbols(stopPositions[i]);
                for (int j = 0; j < 3; j++)
                    screen[j][i] = visibleSymbols[j];
            }
            return screen;
        }

        public void DisplayScreen(SpinResult spinResult)
        {
            Console.WriteLine($"Stop Positions: {string.Join(", ", spinResult.StopPositions)}");
            Console.WriteLine("Screen:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write($"{spinResult.Screen[i][j]} ");
                Console.WriteLine();
            }
        }
    }
}
