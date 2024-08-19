using SlowMachine_API.Services;
using Testing.Mock;
namespace Testing
{
    public class SlotMachineTests
    {
        [Fact]
        public void CheckTotalSum()
        {
            for (int i = 0; i < MockDatas.ReelBands.Count; i++)
            {
                var reelConfig = new MockReelConfig(MockDatas.ReelBands[i], MockDatas.StopPositions[i]);
                var paytableConfig = new MockPaytableConfig();

                var slotMachineService = new SlotMachineService
                {
                    Config = reelConfig
                };

                var payoutService = new PayoutService
                {
                    Config = paytableConfig
                };
                var spinResult = slotMachineService.SpinReels();

                payoutService.CalculateWinnings(spinResult);

                Assert.Equal(MockDatas.TotalWinningsResuls[i], spinResult.GetTotalWinnings());
            }
        }


        [Fact]
        public void CheckCombinations()
        {
            var paytableConfig = new MockPaytableConfig();

 
            var payoutService = new PayoutService
            {
                Config = paytableConfig
            };

            string[][] screen = new string[3][];
            for (int i = 0; i < screen.Length; i++)
                screen[i] = new string[5];

            screen[0] = ["sym1", "sym2", "sym3", "sym4", "sym3"];
            screen[1] = ["sym5", "sym6", "sym5", "sym5", "sym2"];
            screen[2] = ["sym7", "sym8", "sym1", "sym1", "sym5"];

            var spinResult = new SlowMachine_API.Models.SpinResult([], screen);

            payoutService.CalculateWinnings(spinResult);
            spinResult.PrintWinnings();
        }
    }
}