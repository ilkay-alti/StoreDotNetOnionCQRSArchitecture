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

namespace StoreOnionArchitecture.Application.Features.Brands.Querries.GetAllBrannds
{
    public class GetAllBranndsHandler : BaseHandler, IRequestHandler<GetAllBranndsRequest, IList<GetAllBranndsResponse>>
    {
        public GetAllBranndsHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) 
            : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBranndsResponse>> Handle(GetAllBranndsRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return _mapper.Map<GetAllBranndsResponse,Brand>(brands);
        }
    }
}
