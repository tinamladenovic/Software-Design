using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class AuthorEquipmentRepository : IAuthorEquipmentRepository
    {
        private readonly ToursContext _context;

        public AuthorEquipmentRepository(ToursContext context)
        {
            _context = context;
        }

        /*public Result<PagedResult<TourEquipment>> GetEquipmentByTourId(int tourId, int page, int pageSize)
        {

            var count = _context.Equipment.Where(t => t.TourId == tourId).Count();

            IQueryable<TourEquipment> query = _context.Equipment.Where(t => t.TourId == tourId);

            List<TourEquipment> items;

            //if (pageSize != 0 && page != 0)
            //{
            //    query.Skip((page - 1) * pageSize).Take(pageSize);
            //    items = query.ToList();
            //}
            //else
            //{
            //    items = new List<Tour>();
            //}

            items = query.ToList();

            return new PagedResult<TourEquipment>(items, count);
        }*/
    }
}
