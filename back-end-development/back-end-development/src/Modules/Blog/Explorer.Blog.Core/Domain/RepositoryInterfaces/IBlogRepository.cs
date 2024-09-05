using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain.RepositoryInterfaces
{
    public interface IBlogRepository
    {
        BlogDom? GetById(long blogId);
        BlogDom UpdateBlog(BlogDom blog);
    }
}
