using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Status = Explorer.Tours.Core.Domain.Tours.Status;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRepository : ITourRepository

    {
        private readonly ToursContext _context;
        private readonly DbSet<Tour> _dbSet;

        public TourRepository(ToursContext context)
        {
            _context = context;
            _dbSet = context.Set<Tour>();
        }

        public Result<PagedResult<Tour>> GetAllAvailableTours(int page, int pageSize)
        {
            IQueryable<Tour> items = _dbSet.Include(e => e.TourReviews)
                .Include(e => e.FavouriteTours)
                .Include(e => e.Checkpoints)
                .Where(e => e.Status == Core.Domain.Tours.Status.PUBLISHED);

            var count = items.Count();

            if (pageSize != 0 && page != 0)
            {
                items = _dbSet.OrderByDescending(e => e.Id).Include(e => e.TourReviews).Include(e => e.FavouriteTours).Include(e => e.Checkpoints).Skip((page - 1) * pageSize).Take(pageSize);
            }
            
            return new PagedResult<Tour>(items.ToList(), count);
        }

        public Result<PagedResult<Tour>> GetByAuthorId(long authorId, int page, int pageSize)
        {

            var count = _context.Tours.Where(t => t.AuthorId == authorId).Count();

            IQueryable<Tour> query = _context.Tours.Where(t => t.AuthorId == authorId);

            List<Tour> items;

            //if (pageSize != 0 && page != 0)
            //{
            //    query.Skip((page - 1) * pageSize).Take(pageSize);
            //    items = query.ToList();
            //}
            //else
            //{
            //    items = new List<Tour>();
            //}

            items = query.Include(t => t.TourEquipment).ToList();

            return new PagedResult<Tour>(items, count);
        }

        public Result<PagedResult<Tour>> GetPublishedAuthorTours(long authorId, int page, int pageSize)
        {

            var count = _context.Tours.Where(t => t.AuthorId == authorId && t.Status == Core.Domain.Tours.Status.PUBLISHED).Count();

            IQueryable<Tour> query = _context.Tours.Where(t => t.AuthorId == authorId && t.Status == Core.Domain.Tours.Status.PUBLISHED);

            List<Tour> items;

            //if (pageSize != 0 && page != 0)
            //{
            //    query.Skip((page - 1) * pageSize).Take(pageSize);
            //    items = query.ToList();
            //}
            //else
            //{
            //    items = new List<Tour>();
            //}

            items = query.Include(t => t.TourEquipment).ToList();

            return new PagedResult<Tour>(items, count);
        }

        //Eagerly loading of objects

        public IEnumerable<Tour> GetAll()
        {
            return _context.Tours
                .Include(t => t.Checkpoints)
                .ToList();
        }
       
       public Tour GetById(long id)
        {
            var entity = _context.Tours.FirstOrDefault(t => t.Id == id);
            if(entity == null) throw new KeyNotFoundException("Not found.");
            return entity;
        }

       public Result<PagedResult<Tour>> GetSuggestions(int page, int pageSize, long[] checkpoints)
       {
           var query = _context.Tours.Include(t => t.Checkpoints).Where(t => t.Status == Status.PUBLISHED);
           var tours = query.ToList();
           var result = new List<Tour>();

           foreach (var tour in tours)
           {
               var tourCheckpoints = tour.Checkpoints.Select(c => c.Id).ToArray();
               var intersection = tourCheckpoints.Intersect(checkpoints);
               if (intersection.Count() == checkpoints.Length)
               {
                   result.Add(tour);
               }
           }
           return new PagedResult<Tour>(result, result.Count);
       }

       public void AddCheckpoints(List<int> checkpoints, int tourId)
       {
              var tour = _context.Tours.Include(t => t.Checkpoints).FirstOrDefault(t => t.Id == tourId);
              if (tour == null) throw new KeyNotFoundException("Not found.");
              long max = _context.Checkpoints.Max(c => c.Id);
              int i = 1;
              foreach (var checkpointId in checkpoints)
              {
                var checkpoint = _context.Checkpoints.FirstOrDefault(c => c.Id == checkpointId);
                var newCheckpoint = new Checkpoint(max+i, checkpoint.Name, checkpoint.Description, checkpoint.PictureURL,
                    new Coordinate(checkpoint.Coordinates.Latitude, checkpoint.Coordinates.Longitude), tourId);
                if (checkpoint == null) throw new KeyNotFoundException("Not found.");
                _context.Checkpoints.Add(newCheckpoint);
                tour.Checkpoints.Add(newCheckpoint);
                i++;
              }
              _context.SaveChanges();
       }

       public void AddFavoriteTour(int touristId, int tourId)
       {
           var tour = _context.Tours.FirstOrDefault(t => t.Id == tourId);
           if (tour == null) throw new KeyNotFoundException("Not found.");
           var favt = _context.Set<FavouriteTour>();
              var fav = new FavouriteTour(touristId,tourId);
              favt.Add(fav);
           _context.SaveChanges();
       }

       public void RemoveFavoriteTour(int touristId, int tourId)
       {
           try
           {
                var favt = _context.Set<FavouriteTour>();
                var fav = favt.FirstOrDefault(f => f.TouristId == touristId && f.TourId == tourId);
                if (fav == null) throw new KeyNotFoundException("Not found.");
                favt.Remove(fav);
               _context.SaveChanges();
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }
           
       }
        public long GetRandomTourAuthorByTour()
        {
            // Dohvati sve aktivne i objavljene ture
            var publishedTours = _context.Tours
                .Where(t => t.Status == Status.PUBLISHED)
                .ToList();

            // Provjeri jesu li pronađene objavljene ture
            if (publishedTours.Count == 0)
            {
                throw new KeyNotFoundException("No published tours found.");
            }

            // Generiraj slučajan indeks kako biste odabrali objavljenu turu
            var randomIndex = new Random().Next(0, publishedTours.Count);

            // Dohvati slučajno odabranu objavljenu turu
            var randomPublishedTour = publishedTours[randomIndex];

            return randomPublishedTour.AuthorId;
        }
    }      
}
