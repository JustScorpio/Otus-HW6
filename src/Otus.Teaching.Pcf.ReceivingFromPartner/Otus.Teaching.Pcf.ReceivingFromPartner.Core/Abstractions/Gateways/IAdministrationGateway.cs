using System;
using System.Threading.Tasks;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.Core.Abstractions.Gateways
{
    public interface IAdministrationGateway
    {
        Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId);
    }
}