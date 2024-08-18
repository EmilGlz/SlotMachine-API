using Microsoft.AspNetCore.Mvc;
using SlotMachine.Config;
using SlowMachine_API.Config;
using SlowMachine_API.Services;

namespace SlowMachine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var reelConfig = new ReelConfig();
            var paytableConfig = new PaytableConfig();

            var slotMachineService = new SlotMachineService(reelConfig);
            var payoutService = new PayoutService(paytableConfig);

            var spinResult = slotMachineService.SpinReels();

            slotMachineService.DisplayScreen(spinResult);

            payoutService.CalculateWinnings(spinResult);

            return Ok(spinResult);
        }
    }
}
