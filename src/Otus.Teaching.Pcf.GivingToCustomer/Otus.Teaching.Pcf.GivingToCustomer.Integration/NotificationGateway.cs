using System;
using System.Threading.Tasks;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Gateways;

namespace Otus.Teaching.Pcf.GivingToCustomer.Integration
{
    public class NotificationGateway
        : INotificationGateway
    {
        public Task SendNotificationToPartnerAsync(Guid partnerId, string message)
        {
            //Код, который вызывает сервис отправки уведомлений партнеру
            
            return Task.CompletedTask;
        }
    }
}