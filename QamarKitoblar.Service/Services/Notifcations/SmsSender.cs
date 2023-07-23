using QamarKitoblar.Service.Dtos.Notifcations;
using QamarKitoblar.Service.Interafaces.Notifcations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Notifcations
{
    public class SmsSender : ISmsSender
    {
        public async Task<bool> SendAsync(SmsMessage smsMessage)
        {
            throw new NotImplementedException();
        }
    }
}
