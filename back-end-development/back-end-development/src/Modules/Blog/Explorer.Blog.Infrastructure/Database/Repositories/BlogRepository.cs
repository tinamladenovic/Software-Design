using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Infrastructure.Database.Repositories
{
    public class BlogRepository : CrudDatabaseRepository<BlogDom, BlogContext>, IBlogRepository
    {
        public BlogRepository(BlogContext dbContext) : base(dbContext) { }

        public BlogDom? GetById(long blogId)
        {
           return DbContext.Blogs.FirstOrDefault(b => b.Id == blogId);
        }

        public BlogDom UpdateBlog(BlogDom blog)
        {
            return Update(blog);
        }
    }
}
