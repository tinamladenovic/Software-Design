using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Stakeholders.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Difficult = Explorer.Tours.Core.Domain.Tours.Difficult;

namespace Explorer.Tours.Core.Recommendation
{
    public class TourRecommender : ITourRecommender
    {
        private readonly ITourService _tourService;
        private readonly ITourPreferencesService _tourPreferencesService;
        private readonly ITourRatingService _tourRatingService;
        private readonly ITourExecutionService _tourExecutionService;
        private readonly IMapper _mapper;

        public TourRecommender(ITourService tourService, ITourPreferencesService tourPreferencesService, ITourRatingService tourRatingService,
            ITourExecutionService tourExecutionService)
        {
            _tourService = tourService;
            _tourPreferencesService = tourPreferencesService;
            _tourRatingService = tourRatingService;
            _tourExecutionService = tourExecutionService;
        }

        public Result<PagedResult<TourDto>> RearangeTours(List<TourDto> sentTours,long touristId)
        {
            var pref = _tourPreferencesService.GetByTourist(touristId).Value;
            var finishedTours = GetTours(_tourExecutionService.GetLast10FinishedTours(touristId).Value);

            var tagsCount = CountTags(finishedTours);

            var sortedTours = SortTours(sentTours, pref, tagsCount).ToList();

            return new PagedResult<TourDto>(sortedTours, sortedTours.Count);
        }

        public Result<PagedResult<TourDto>> GetRecommendedTours(long touristId)
        {
            var pref = _tourPreferencesService.GetByTourist(touristId).Value;
            var finishedTours = GetTours(_tourExecutionService.GetLast10FinishedTours(touristId).Value); 
            var highlyRatedTours = GetTours(_tourRatingService.GetHighlyRatedTours().Value); 


            var tagsCount = CountTags(finishedTours); // preferred tourist tags based on finished tours

            var sortedTours = SortTours(highlyRatedTours, pref, tagsCount).Take(10).ToList();

            return new PagedResult<TourDto>(sortedTours, sortedTours.Count);
        }

        private List<TourDto> GetTours(List<long> tourIds)
        {
            var result = new List<TourDto>();
            foreach (var tourId in tourIds)
            {
                result.Add(_tourService.GetById(tourId).Value);
            }
            return result;
        }
        private Dictionary<string, int> CountTags(IEnumerable<TourDto> tours)
        {
            var result = new Dictionary<string, int>();
            foreach (var tour in tours)
            {
                if (tour.Tags.Contains(','))
                {
                    var tags = tour.Tags.Split(",");
                    foreach (var tag in tags)
                    {
                        if (result.ContainsKey(tag))
                        {
                            result[tag]++;
                        }
                        else
                        {
                            result[tag] = 1;
                        }
                    }
                }
                else
                {
                    if (result.ContainsKey(tour.Tags))
                    {
                        result[tour.Tags]++;
                    }
                    else
                    {
                        result[tour.Tags] = 1;
                    }
                }
            }
            return result;
        }

        private IEnumerable<TourDto> SortTours(IEnumerable<TourDto> tours, TourPreferencesDto preference, Dictionary<string, int> finishedPreferences)
        {

            var sortedTours = tours.OrderByDescending(tour =>
            {
                var tagScore = CalculateTagScore(tour.Tags, preference.Tags, finishedPreferences);
                var preferenceScore = CalculateTravelMethodScore(tour.TravelTimeAndMethod, preference.TourTravelMethod);
                var difficultyScore = CalculateDifficultyScore(tour, preference.TourDifficult);

                var totalScore = tagScore + preferenceScore + difficultyScore;

                return totalScore;
            });

            return sortedTours;
        }

        private double CalculateTagScore(string tourTags, string preferenceTag, Dictionary<string, int> finishedPreferences)
        {
            double score = 0;

            if (preferenceTag.Contains(","))
            {
                var prefTags = preferenceTag.Split(",");
                foreach (var tag in prefTags)
                {
                    if (tourTags.Contains(tag))
                    {
                        score = score + 1;
                    }
                }
            }

            if (tourTags.Contains(","))
            {
                var tags = tourTags.Split(',');
                foreach (var tag in tags)
                {
                    var founded = finishedPreferences.Keys.FirstOrDefault(fp => fp == tag);
                    if (founded != null)
                    {
                        score += 1 * finishedPreferences[founded];
                    }
                }
            }
            else
            {
                var founded = finishedPreferences.Keys.FirstOrDefault(fp => fp == tourTags);
                if (founded != null)
                {
                    score += 1 * finishedPreferences[founded];
                }
            }


            return (double)score;
        }

        private double CalculateTravelMethodScore(IEnumerable<TravelTimeAndMethodDto> travelTimeAndMethods, string preference)
        {
            var score = 0;
            foreach (var method in travelTimeAndMethods)
            {
                if (method.TravelMethod.ToString().ToLower().Equals(preference.ToLower()))
                {
                    score += 1;
                }
            }

            return score;
        }

        private double CalculateDifficultyScore(TourDto tour, string preferenceDifficulty)
        {
            var tourDifficulty = tour.Difficult;
            var preferenceEnum = (Difficult)Enum.Parse(typeof(Difficult), preferenceDifficulty, true);

            var difficultyDifference = Math.Abs((int)tourDifficulty - (int)preferenceEnum);

            var score = 1.0 / (difficultyDifference + 1);

            return score;
        }
    }
}