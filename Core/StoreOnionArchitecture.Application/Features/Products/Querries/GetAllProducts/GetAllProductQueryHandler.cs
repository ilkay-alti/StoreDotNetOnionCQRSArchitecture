using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Products.Querries.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {

            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            List<GetAllProductQueryResponse> response = new();

            foreach (var product in products)
                response.Add(new GetAllProductQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price-(product.Price * product.Discount/100),
                    Discount = product.Discount

                });

            
            return response;
        }

    }
}
