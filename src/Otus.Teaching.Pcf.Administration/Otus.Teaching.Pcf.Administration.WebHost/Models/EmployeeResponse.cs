using System;
using System.Collections.Generic;
using Otus.Teaching.Pcf.Administration.Core.Domain.Administration;

namespace Otus.Teaching.Pcf.Administration.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public RoleItemResponse Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}