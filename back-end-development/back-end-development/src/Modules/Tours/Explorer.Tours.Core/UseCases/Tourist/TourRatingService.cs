using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TourRatingService : CrudService<TourRatingDto, TourRating>, ITourRatingService
{
    private readonly ITourRatingRepository _tourRatingRepository;

    public TourRatingService(IMapper mapper, ITourRatingRepository tourRatingRepository) : base(tourRatingRepository, mapper)
    {
        _tourRatingRepository = tourRatingRepository;
    }

    public Result<int> GetRatingsCountForPastWeek(long tourId)
    {
        return _tourRatingRepository.GetRatingsCountForPastWeek(tourId);
    }

    public Result<double> GetAverageRatingForPastWeek(long tourId)
    {
       return _tourRatingRepository.GetAverageRatingForPastWeek(tourId);
    }

    public Result<List<long>> GetHighlyRatedTours()
    {
        var ratings = _tourRatingRepository.GetAll().Value;

        var highlyRatedTours = ratings
            .GroupBy(tr => tr.TourId)
            .Where(group => group.Count() > 3 && group.Average(tr => tr.Rating) > 3.9)
            .Select(group => new { TourId = group.Key, AverageRating = group.Average(tr => tr.Rating) })
            .Distinct()
            .ToList();

        var result = highlyRatedTours.Select(item => (long)item.TourId).ToList();

        return result;
    }

    public float GetAverageGradeForTour(long id) 
    {
        float sum=0;
        float number = 0;
        List<TourRating> ratings = _tourRatingRepository.GetAllByToursIdList(id);
        foreach (TourRating tr in ratings) 
        {
            sum = sum + tr.Rating;
            number = number + 1;
        }
        return (sum / number);
    }

    public List<int> GetAllGradesForTour(long id) 
    {
        List<int> grades = new List<int>();
        List<TourRating> ratings = _tourRatingRepository.GetAllByToursIdList(id);
        foreach (TourRating tr in ratings)
        {
            grades.Add(tr.Rating);
        }
        return grades;
    }

}

