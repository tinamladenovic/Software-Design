using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Route("api/tour")]
    public class TourController : BaseApiController
    {
        private readonly ITourService _tourService;
        private readonly ICheckpointService _checkpointService;

        public TourController(ITourService tourService, ICheckpointService checkpointService)
        {
            _tourService = tourService;
            _checkpointService = checkpointService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }


        [HttpGet("authortours")]
        [AllowAnonymous]
        public ActionResult<PagedResult<TourDto>> GetAllAuthorTours([FromQuery] int authorId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourService.GetByAuthorId(authorId, page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("singletour")]
        public ActionResult<TourDto> GetById([FromQuery] int tourId) {
            var result = _tourService.Get(tourId);
            return CreateResponse(result);
        }

        [HttpGet("singletour/{tourId:int}")]
        public ActionResult<TourDto> GetTour(int tourId)
        {
            var result = _tourService.Get(tourId);
            return CreateResponse(result);
        }

        [HttpPut("updatetour")]
        public ActionResult<TourDto> Update([FromBody] TourDto tourDto)
        {

            var result = _tourService.Update(tourDto);
            return CreateResponse(result);


        }

        [HttpPost]
        public ActionResult<TourDto> Create([FromBody] TourDto tour)
        {
            var result = _tourService.Create(tour);
            return CreateResponse(result);
        }

        [HttpPost("addCheckpoint")]
        public ActionResult<CheckpointDto> AddCheckpointOnTour([FromBody] CheckpointDto checkpointDto)
        {
            var result = _checkpointService.Create(checkpointDto);
            return CreateResponse(result);
        }

        [HttpPatch("addCheckpoint/{tourId:int}")]

        public void AddCheckPointOnTour(int? tourId, [FromBody] CheckpointDto checkpointDto)
        {
            _checkpointService.Create(checkpointDto);
        }

        [HttpGet("getCheckpoints/{tourId:int}")]

        public ActionResult<PagedResult<CheckpointDto>> GetAllByTourId([FromQuery] int page, [FromQuery] int pageSize, int tourId)
        {
            var result = _checkpointService.GetAllByTourId(page, pageSize, tourId);
            return CreateResponse(result);
        }

        [HttpPut("updateCheckpoint")]
        public ActionResult<CheckpointDto> UpdateCheckpoint([FromBody] CheckpointDto checkpointDto)
        {
            var result = _checkpointService.Update(checkpointDto);
            return CreateResponse(result);
        }

        [HttpDelete("deleteCheckpoint/{checkpointId:int}")]
        public ActionResult<CheckpointDto> DeleteCheckpoint(int checkpointId)
        {
            var result = _checkpointService.Delete(checkpointId);
            return CreateResponse(result);
        }

        [HttpGet("tourist/checkpoints")]
        public ActionResult<PagedResult<CheckpointDto>> GetTouristCheckpoints([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _checkpointService.GetAllPublicCheckpoints(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost("acceptRequest/{checkpointId:long}")]
        public ActionResult<CheckpointDto> AcceptRequest(int checkpointId)
        {
            var result = _checkpointService.AcceptCheckpoint(checkpointId);
            return CreateResponse(result);
        }

        [HttpPost("declineRequest/{checkpointId:int}")]
        public ActionResult<CheckpointDto> DeclineRequest(int checkpointId, [FromBody] string comment)
        {
            var result = _checkpointService.RejectCheckpoint(checkpointId, comment);
            return CreateResponse(result);
        }

        [HttpPut("publishTour")]
        public ActionResult<TourDto> PublishTour([FromBody] int tourId)
        {
            if (_checkpointService.CheckPointsAreValidForPublish(0, 0, tourId))
            {
                _tourService.PublishTour(tourId, DateTime.Now.ToUniversalTime());
                var tour = _tourService.Get(tourId);
                return CreateResponse(tour);
            }
            else
            {
                throw new Exception("Tour doesn't have enough checkpoints to be published ");
            }
        }

        [HttpPut("archiveTour")]
        public ActionResult<TourDto> ArchiveTour([FromBody] int tourId)
        {
            _tourService.ArchiveTour(tourId, DateTime.Now.ToUniversalTime());
            var tour = _tourService.Get(tourId);
            return CreateResponse(tour);
        }

        [HttpGet("shopping/{userId:int}")]
        public ActionResult<PagedResult<TourPreviewDto>> GetAllAvailableTours([FromQuery] int page, [FromQuery] int pageSize, int userId)
        {
            var result = _tourService.GetAllAvailableTours(page, pageSize, userId);
            return CreateResponse(result);
        }
        
        [HttpGet("touristTours/{userId:int}")]
        public ActionResult<PagedResult<TourPreviewDto>> GetTouristTours([FromQuery] int page, [FromQuery] int pageSize, int userId)
        {
            var result = _tourService.GetTouristTours(page, pageSize, userId);
            return CreateResponse(result);

        }

        [HttpGet("publishedauthortours")]
        public ActionResult<PagedResult<TourDto>> GetPublishedAuthorTours([FromQuery] int authorId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourService.GetPublishedAuthorTours(authorId, page, pageSize);
            return CreateResponse(result);
        }
        
        [HttpGet("administrator/checkpoints")]
        [AllowAnonymous]
        public ActionResult<PagedResult<CheckpointDto>> GetAdministratorCheckpoints([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _checkpointService.GetAllAdministratorCheckpoints(page, pageSize);
            return CreateResponse(result);
        }
        
        [HttpGet("suggestedTours")]
        [AllowAnonymous]
        public ActionResult<PagedResult<TourDto>> GetSuggestedTours([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] long[] ids)
        {
            var result = _tourService.GetSuggestions(page, pageSize, ids);
            return CreateResponse(result);
        }
        
        [HttpPost("{tourId:int}/checkpoints")]
        [AllowAnonymous]
        public void AddCheckpointsOnTour(int tourId, [FromBody] List<int> checkpoints)
        {
            _tourService.AddCheckpoints(checkpoints, tourId);
        }
        
        [HttpPost("{tourId:int}/favorite")]
        [AllowAnonymous]
        public void AddFavoriteTour(int tourId)
        {
            var userId = ClaimsPrincipalExtensions.UserId(User);
            _tourService.AddFavoriteTour(userId, tourId);
        }
        
        [HttpDelete("{tourId:int}/favorite")]
        [AllowAnonymous]
        public void RemoveFavoriteTour(int tourId)
        {
            var userId = ClaimsPrincipalExtensions.UserId(User);
            _tourService.RemoveFavoriteTour(userId, tourId);
        }
    }
}
