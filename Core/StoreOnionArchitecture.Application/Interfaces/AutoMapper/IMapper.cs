using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnionArchitecture.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);

        //list
        IList<TDestination>Map<TDestination,TSource>(IList<TSource> source, string? ignore = null);
        // obj
        TDestination Map<TDestination>(object source, string? ignore = null);
        TDestination Map<TDestination>(IList<object> source, string? ignore = null);

    }
}


//maper.Map<BrandDTO,Brand>(brand) return BrandDto
//maper.Map<Brand,BrandDTO>(brand) return Brand