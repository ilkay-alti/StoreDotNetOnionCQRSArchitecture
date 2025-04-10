using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreOnionArchitecture.Application.Interfaces.RedisCache;

namespace StoreOnionArchitecture.Application.Features.Products.Querries.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductQueryResponse>>,ICacheableQuery
    {
        public string CacheKey => "GetAllProducts";
        public double CacheTime => 60;

    }
}
