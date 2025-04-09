using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Bases
{
    public class BaseHandler
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly string _userId;
        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
