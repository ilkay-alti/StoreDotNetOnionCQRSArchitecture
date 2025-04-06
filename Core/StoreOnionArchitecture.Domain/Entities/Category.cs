
using StoreOnionArchitecture.Domain.Common;

namespace StoreOnionArchitecture.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }

        public Category(int parentId, string name, int priorty) {

            Priorty = priorty;
            ParentId = parentId;
            Name = name;


        }
        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; } 

    }
}
