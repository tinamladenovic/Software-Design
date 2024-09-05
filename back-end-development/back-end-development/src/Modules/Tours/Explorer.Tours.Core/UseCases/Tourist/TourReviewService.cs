using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.API.Public.Tourist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Explorer.Tours.Core.UseCases.Tourist
{
      public class TourReviewService :  CrudService<TourReviewDto, TourReview>, ITourReviewService
      {
           public TourReviewService(ICrudRepository<TourReview> repository, IMapper mapper) : base(repository, mapper) {}
      }
    
}
