using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace StoreOnionArchitecture.Application.Features.Products.Querries.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductQueryResponse>>
    {

    }
}
