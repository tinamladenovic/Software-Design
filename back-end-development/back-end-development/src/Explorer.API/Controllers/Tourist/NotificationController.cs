using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristAndAdminPolicy")]
    [Route("api/notifications/users")]
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public ActionResult<PagedResult<NotificationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _notificationService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
        [HttpPost]
        public ActionResult<NotificationDto> Create([FromBody] NotificationDto request)
        {
            //var result = _notificationService.Create(request);
            //return CreateResponse(result);
            Result<NotificationDto> result = null;
            try
            {
                result = _notificationService.Create(request);
            }
            catch (DbUpdateException ex)
            {
                result = Result.Fail(FailureCode.InvalidArgument).WithError("");
            }

            return CreateResponse(result);
        }
        [HttpPut("{id:int}")]
        public ActionResult<NotificationDto> Update([FromBody] NotificationDto request)
        {
            var result = _notificationService.Update(request);
            return CreateResponse(result);
        }
    }
}
