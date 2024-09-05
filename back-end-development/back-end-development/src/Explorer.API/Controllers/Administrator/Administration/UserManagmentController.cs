using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administration/users")]
    
    public class UserManagmentController : BaseApiController
    {
        private readonly IUserManagmentService _userManagmentService;
        
        public UserManagmentController(IUserManagmentService userManagmentService)
        {
            _userManagmentService = userManagmentService;
        }
        
        [HttpGet]
        public ActionResult<PagedResult<UserDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _userManagmentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
        
        [HttpPut("{id:long}/block")]
        public ActionResult<UserDto> Block(long id)
        {
            var result = _userManagmentService.Block(id);
            return CreateResponse(result);
        }
    }
}