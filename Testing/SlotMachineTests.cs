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
    }
}