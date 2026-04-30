using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Context;
using CarBookDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetListCarWithBrand()
        {
            var values = await _context.Cars.Include(x => x.brand).ToListAsync();
            return values;
        }
    }

}
