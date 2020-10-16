using System;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Gateways
{
    public interface INotificationGateway
    {
        Task SendNotificationToPartnerAsync(Guid partnerId, string message);
    }
}