using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreOnionArchitecture.Application.Interfaces.RedisCache;

namespace StoreOnionArchitecture.Application.Features.Brands.Querries.GetAllBrannds
{
    public class GetAllBranndsRequest:IRequest<IList<GetAllBranndsResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";
        public double CacheTime => 5;
    }
}
