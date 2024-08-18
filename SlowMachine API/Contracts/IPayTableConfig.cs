using SlowMachine_API.Models;
namespace SlowMachine_API.Contracts
{
    public interface IPayTableConfig
    {
        public Paytable Paytable { get; protected set; }
    }
}
