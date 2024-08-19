using SlowMachine_API.Models;

namespace SlowMachine_API.Contracts
{
    public interface IPayoutService
    {
        public IPayTableConfig Config { get; protected set; }
        public void CalculateWinnings(SpinResult spinResult);
    }
}
