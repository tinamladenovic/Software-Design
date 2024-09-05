using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public enum Status
    {
        Draft,
        Published,
        Active,
        Famous,
        Closed
    }

    public class BlogDom : Entity
    {
        public string Name { get; init; }
        public string? Description { get; init; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime DateCreated { get; init; }
        public string[]? Images { get; init; }
        public long AuthorId { get; init; }
        public Status Status { get; set; }
        public int Rating { get; set; }    
        public List<Comment> Comments { get; init; }
        public List<Rating> Ratings { get; init; }  


        public BlogDom(string name, string? description, DateTime dateCreated, string[]? images, Status status, long authorId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");

            Name = name;
            Description = description;
            DateCreated = dateCreated;
            Images = images;
            Status = Status.Published;

            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            Rating = 0;
            AuthorId = authorId;
        }

        public List<Rating> AddRating(Rating rating, long authorId)
        {
            if (authorId != rating.UserId) return Ratings;
            
            var rat = Ratings.Find(r => r.UserId == rating.UserId);
            if(rat != null)
            {
                rat.ChangeRating(rating);
            }
            else
            {
                Ratings.Add(rating);
            }
            //Check if status changed
            CheckStatus();
            return Ratings;
        }


        /*
         * authorId - author of comment that is about to be deleted
         * userId - logged user who requested comment deletion
         
        */
        public List<Rating> DeleteRating(long authorId, long userId)
        {
            var rat = Ratings.Find(r => r.UserId == authorId);
            if (rat == null || userId != authorId) return Ratings;
            Ratings.Remove(rat);
            CheckStatus();
            return Ratings;
        }

        public List<Comment> AddComment(Comment comment, long authorId)
        {
            if (authorId != comment.UserId) return Comments;

            //Daj mi sve komentare koje je napisao logovani korisnik
            var comms = Comments.FindAll(c => c.UserId == comment.UserId);
            if(comms.Count > 0)
            {
                foreach (var comm in comms)
                {

                    //proveri da li komentar vec postoji - samo cemo ga izmeniti
                    if(comm.CreationTime == comment.CreationTime)
                    {
                        comm.ChangeComment(comment);
                        CheckStatus();
                        return Comments;
                    }
                }
                
            }
            //Ako u listi ne postoji ni jedan komentar ili postoje komentari koji se razlikuju od ovog - kreiraj 
            Comments.Add(comment);
            
            //Check if status changed
            CheckStatus();
            return Comments;
        }

        public List<Comment> DeleteComment(DateTime creationTime, long authorId)
        {
            var comm = Comments.Find(c => c.CreationTime == creationTime);
            if (comm == null || authorId != comm.UserId) return Comments;
            Comments.Remove(comm);
            CheckStatus();
            return Comments;
        }

        private void CheckStatus()
        {
            Rating = 0;
            foreach(var rat in Ratings)
            {
                if (rat.RatingType == RatingType.Upwote) Rating++;
                else if (rat.RatingType == RatingType.Downvote) Rating--;
            }
            if (Rating < -10) Status = Status.Closed;
            if (Rating > 100 || Comments.Count() > 10) Status = Status.Active;
            if (Rating > 500 && Comments.Count() > 30) Status = Status.Famous; 
        }
    }
}
