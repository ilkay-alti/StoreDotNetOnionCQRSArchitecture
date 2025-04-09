using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = _mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == request.Id);

            await _unitOfWork.GetWriteRepository<ProductCategory>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {

                await _unitOfWork.GetWriteRepository<ProductCategory>()
                    .AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,
                    });

            }
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();

            return Unit.Value;


        }
    }
}