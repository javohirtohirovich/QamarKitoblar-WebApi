using QamarKitoblar.Service.Dtos.Notifcations;

namespace QamarKitoblar.Service.Interafaces.Notifcations;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}

