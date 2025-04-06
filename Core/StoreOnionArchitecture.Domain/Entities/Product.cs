using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Domain.Common;

namespace StoreOnionArchitecture.Domain.Entities
{
    public class Product:EntityBase
    {

        public Product() { }
        public Product(string title, string description, int brandId, int price, decimal discount)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }


        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public required int Price { get; set; }
        public required decimal Discount { get; set; }

        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
