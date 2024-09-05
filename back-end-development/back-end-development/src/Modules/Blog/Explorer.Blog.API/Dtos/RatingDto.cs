using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Dtos
{
    public enum RatingTypeDto { 
        Upwote,
        Downvote,
    }

    public class RatingDto
    {
        public long UserId { get; set; }
        public string Author { get; set; }
        public RatingTypeDto RatingType { get; set; }
    }
}
