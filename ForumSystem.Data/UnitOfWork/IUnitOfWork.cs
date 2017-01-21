
using ForumSystem.Data.Common.Contracts;
using ForumSystem.Models;

namespace ForumSystem.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDeletableEntityRepository<Tag> Tags { get; set; }

        IDeletableEntityRepository<Post> Posts { get; set; }

        IDeletableEntityRepository<Answer> Answers { get; set; }

        IDeletableEntityRepository<Vote> Votes { get; set; }

        IDeletableEntityRepository<Comment> Comments{ get; set; }

        int SaveChanges();
    }
}
