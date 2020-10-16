using System;
using System.Net.Http;
using System.Threading.Tasks;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Abstractions.Gateways;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.Integration
{
    public class AdministrationGateway
        : IAdministrationGateway
    {
        private readonly HttpClient _httpClient;

        public AdministrationGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task NotifyAdminAboutPartnerManagerPromoCode(Guid partnerManagerId)
        {
            var response = await _httpClient.PostAsync($"api/v1/employees/{partnerManagerId}/appliedPromocodes", 
                new StringContent(string.Empty));

            response.EnsureSuccessStatusCode();
        }
    }
}