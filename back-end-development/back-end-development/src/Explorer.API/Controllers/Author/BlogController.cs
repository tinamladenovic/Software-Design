using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.UseCases;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    
    [Route("api/blogs/")]
    public class BlogController : BaseApiController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Authorize(Policy = "authorPolicy")]
        [HttpPost]
        public ActionResult<BlogDto> Create([FromBody] BlogDto blog)
        {
            var result = _blogService.Create(blog);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<BlogDto>> GetAllBlogs([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _blogService.GetAll(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PagedResult<BlogDto>> GetBlogById(int id)
        {
            var result = _blogService.GetById(id);
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpPost("{blogId}/comments")]
        public ActionResult<BlogDto> CreateComment(long blogId, [FromBody] CommentDto comment)
        {
            var result = _blogService.CreateOrUpdateComment(blogId, comment, User.UserId());
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpPatch("{blogId}/comments")]
        public ActionResult<BlogDto> UpdateComment(long blogId, [FromBody] CommentDto comment)
        {
            var result = _blogService.CreateOrUpdateComment(blogId, comment, User.UserId());
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpDelete("{blogId}/comments/{creationTime}")]
        public ActionResult<BlogDto> DeleteComment(long blogId, DateTime creationTime)
        {
            var result = _blogService.DeleteComment(blogId, creationTime, User.UserId());
            return CreateResponse(result);
        }


        [Authorize(Policy = "touristPolicy")]
        [HttpPost("{blogId}/ratings")]
        public ActionResult<BlogDto> CreateRating(long blogId, [FromBody] RatingDto rating)
        {
            var result = _blogService.CreateOrUpdateRating(blogId, rating, User.UserId());
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpPatch("{blogId}/ratings")]
        public ActionResult<BlogDto> UpdateRating(long blogId, [FromBody] RatingDto rating)
        {
            var result = _blogService.CreateOrUpdateRating(blogId, rating, User.UserId());
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristPolicy")]
        [HttpDelete("{blogId}/ratings/{userId}")]
        public ActionResult<BlogDto> DeleteRating(long blogId, long userId)
        {
            var result = _blogService.DeleteRating(blogId, userId, User.UserId());
            return CreateResponse(result);
        }


    }
}
