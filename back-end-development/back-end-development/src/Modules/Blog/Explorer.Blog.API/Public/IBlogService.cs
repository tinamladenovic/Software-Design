using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Blog.API.Dtos;

namespace Explorer.Blog.API.Public;
public interface IBlogService
{
    Result<BlogDto> Create(BlogDto blog);
    Result<BlogDto> CreateOrUpdateComment(long blogId, CommentDto comment, long userId);
    Result<BlogDto> DeleteComment(long blogId, DateTime creationTime, long userId);
    Result<BlogDto> CreateOrUpdateRating(long blogId, RatingDto rating, long userId);
    Result<BlogDto> DeleteRating(long blogId, long authorId, long userId);
    Result<PagedResult<BlogDto>> GetAll(int page, int pageSize);
    Result<BlogDto> GetById(long id);

}

