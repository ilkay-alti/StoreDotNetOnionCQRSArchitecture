using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreOnionArchitecture.Application.DTOs;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Products.Querries.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {

            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(predicate:x=>!x.IsDeleted,include:x=>x.Include(b=>b.Brand));

            mapper.Map<BrandDto,Brand>(new Brand());

            //List<GetAllProductQueryResponse> response = new();

            //foreach (var product in products)
            //    response.Add(new GetAllProductQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Price = product.Price-(product.Price * product.Discount/100),
            //        Discount = product.Discount

            //    });

            var map = mapper.Map<GetAllProductQueryResponse, Product>(products);

            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);


            return map;
        }

    }
}
