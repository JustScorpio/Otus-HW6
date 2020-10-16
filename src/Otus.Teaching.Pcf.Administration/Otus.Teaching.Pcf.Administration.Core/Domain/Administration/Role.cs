using System;

namespace Otus.Teaching.Pcf.Administration.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}