using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetListCarWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.brand.Name,
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CarId =x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat=x.Seat,
                Transmission=x.Transmission
            }).ToList();
        }
    }
}
