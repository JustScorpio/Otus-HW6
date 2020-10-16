using System;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain
{
    public class Preference
        :BaseEntity
    {
        public string Name { get; set; }
    }
}