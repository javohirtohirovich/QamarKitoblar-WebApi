using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.Service.Dtos.Notifcations;
using QamarKitoblar.Service.Interafaces.Notifcations;

namespace QamarKitoblar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsSender _smsSender;
        public SmsController(ISmsSender smsSender)
        {
            this._smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendAsync(smsMessage));
        }
    }
}
