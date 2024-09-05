namespace Explorer.Blog.API.Dtos
{
    public class CommentDto
    {
        public string Context { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public long UserId { get; set; }        
        public string Author { get; set; }

    }
}
