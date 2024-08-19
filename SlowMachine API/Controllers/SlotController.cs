using Microsoft.AspNetCore.Mvc;
using SlowMachine_API.Contracts;

namespace SlowMachine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotMachineService _slotMachineService;
        private readonly IPayoutService _payoutService;
        public SlotController(ISlotMachineService service, IPayoutService payoutService)
        {
            _slotMachineService = service;
            _payoutService = payoutService;
        }

        [HttpPost]
        [Route("Run")]
        public IActionResult Run()
        {
            //var paytableConfig = new PaytableConfig();
            //var slotMachineService = new SlotMachineService();
            //var payoutService = new PayoutService(paytableConfig);

            var spinResult = _slotMachineService.SpinReels();
            _payoutService.CalculateWinnings(spinResult);

            return Ok(spinResult);
        }
    }
}
