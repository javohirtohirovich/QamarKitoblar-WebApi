using QamarKitoblar.Service.Dtos.Notifcations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Notifcations;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}

