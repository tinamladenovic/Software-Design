namespace Explorer.Blog.API.Dtos
{

    public enum StatusDto
    {
        Draft,
        Published,
        Active,
        Famous,
        Closed
    }

    public class BlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string[]? Images { get; set; }
        public StatusDto Status { get; set; }
        public long AuthorId { get; set; }  
        public string Author { get; set; }
        public int Rating { get; set; }
        public List<CommentDto> Comments { get; set; } 
        public List<RatingDto> Ratings { get; set; } 

    }
}
