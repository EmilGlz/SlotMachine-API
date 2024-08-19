using SlowMachine_API.Models;
namespace SlowMachine_API.Contracts
{
    public interface ISlotMachineService
    {
        public IReelConfig Config { get; protected set; }

        public SpinResult SpinReels();
    }
}
