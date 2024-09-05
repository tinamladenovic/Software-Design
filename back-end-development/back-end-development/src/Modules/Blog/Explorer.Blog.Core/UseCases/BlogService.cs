using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Internal;
using FluentResults;

namespace Explorer.Blog.Core.UseCases
{
    public class BlogService : CrudService<BlogDto, BlogDom>, IBlogService
    {
        protected readonly IBlogRepository BlogRepository;
        protected readonly IInternalUserService UserService;
        private IMapper _mapper;
        public BlogService(ICrudRepository<BlogDom> crudRepository, IInternalUserService userService, IBlogRepository blogRepository, IMapper mapper) : base(crudRepository, mapper) 
        {
            BlogRepository = blogRepository;
            UserService = userService;
            _mapper = mapper;
        }
        public Result<BlogDto> CreateOrUpdateComment(long blogId, CommentDto comment, long userId)
        {
            try
            {
                var blog = BlogRepository.GetById(blogId);
                if (blog.Status == Status.Closed) throw new Exception("Closed blog can't be modified");
                blog.AddComment(_mapper.Map<Comment>(comment), userId);
                var result = BlogRepository.UpdateBlog(blog);
                
                var blogDto = MapToDto(result);
                FillBlog(blogDto);
                return blogDto;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<BlogDto> DeleteComment(long blogId, DateTime creationTime, long userId)
        {
            try
            {
                var blog = BlogRepository.GetById(blogId);
                if (blog.Status == Status.Closed) throw new Exception("Closed blog can't be modified");
                blog.DeleteComment(creationTime, userId);
                var result = BlogRepository.UpdateBlog(blog);

                var blogDto = MapToDto(result);
                FillBlog(blogDto);
                return blogDto;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<BlogDto> CreateOrUpdateRating(long blogId, RatingDto rating, long userId)
        {
            try
            {
                var blog = BlogRepository.GetById(blogId);
                if (blog.Status == Status.Closed) throw new Exception("Closed blog can't be modified");
                blog.AddRating(_mapper.Map<Rating>(rating), userId);
                var result = BlogRepository.UpdateBlog(blog);
                var blogDto = MapToDto(result);
                FillBlog(blogDto);
                return blogDto;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<BlogDto> DeleteRating(long blogId, long authorId, long userId)
        {
            try
            {
                var blog = BlogRepository.GetById(blogId);
                if (blog.Status == Status.Closed) throw new Exception("Closed blog can't be modified");
                blog.DeleteRating(authorId, userId);
                var result = BlogRepository.UpdateBlog(blog);

                var blogDto = MapToDto(result);
                FillBlog(blogDto);
                return blogDto;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<PagedResult<BlogDto>> GetAll(int page, int pageSize)
        {
            var blogsDto = MapToDto(CrudRepository.GetPaged(page, pageSize));
            foreach(var blog  in blogsDto.Value.Results)
            {
                //Postavljanje Authora kod bloga, komentara i raitinga na osnovu UserId
                FillBlog(blog);
            }
            return blogsDto;
        }

        public Result<BlogDto> GetById(long id)
        {
            var blogDto = MapToDto(BlogRepository.GetById(id));
            FillBlog(blogDto);
            return blogDto;
        }

        private void FillBlog(BlogDto blog)
        {
            // User service - IInternalUserService sa jednom (GetUser) metodom

            blog.Author = UserService.GetUser(blog.AuthorId).Value.Username;
            foreach (var comment in blog.Comments)
            {
                comment.Author = UserService.GetUser(comment.UserId).Value.Username;
            }
            foreach (var rating in blog.Ratings)
            {
                rating.Author = UserService.GetUser(rating.UserId).Value.Username;
            }
        }
    }
}
