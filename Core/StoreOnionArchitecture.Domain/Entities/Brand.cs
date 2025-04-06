using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Domain.Common;

namespace StoreOnionArchitecture.Domain.Entities
{
    public class Brand: EntityBase
    {
        public Brand() { }
        public Brand(string name, string logo, string description)
        {
            Name = name;
            Logo = logo;
            Description = description;
        }
        public required string Name { get; set; }
        public required string Logo { get; set; }
        public required string Description { get; set; }
    }
}
