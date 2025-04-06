using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnionArchitecture.Domain.Common
{
    public class EntityBase:IEntityBase
    {
        public int id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
