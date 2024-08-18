using SlowMachine_API.Models;
namespace SlowMachine_API.Contracts
{
    public interface IReelConfig
    {
        public List<Reel> ReelBands { get; protected set; }

        public int[] GetStopPositions();
    }
}
