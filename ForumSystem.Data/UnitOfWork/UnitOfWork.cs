using ForumSystem.Data.Common.Contracts;
using ForumSystem.Models;
using System.Data.Entity;
using ForumSystem.Data.Base;

namespace ForumSystem.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IDeletableEntityRepository<Comment> comments;
        private IDeletableEntityRepository<Post> posts;
        private IDeletableEntityRepository<Tag> tags;
        private IDeletableEntityRepository<Answer> answers;
        private IDeletableEntityRepository<Vote> votes;


        public UnitOfWork()
            : this(new ForumSystemDbContext())
        {
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public IDeletableEntityRepository<Answer> Answers
        {
            get
            {
                return this.answers ?? (this.answers= new DeletableEntityRepository<Answer>(this.context));
            }
            set
            {
                this.answers = value;
            }
        }

        public IDeletableEntityRepository<Comment> Comments
        {
            get
            {
                return this.comments ?? (this.comments = new DeletableEntityRepository<Comment>(this.context));
            }
            set
            {
                this.comments = value;
            }
        }

        public IDeletableEntityRepository<Post> Posts
        {
            get
            {
                return this.posts ?? (this.posts= new DeletableEntityRepository<Post>(this.context));
            }
            set
            {
                this.posts = value;
            }
        }

        public IDeletableEntityRepository<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new DeletableEntityRepository<Tag>(this.context));
            }
            set
            {
                this.tags = value;
            }
        }

        public IDeletableEntityRepository<Vote> Votes
        {
            get
            {
                return this.votes ?? (this.votes = new DeletableEntityRepository<Vote>(this.context));
            }
            set
            {
                this.votes = value;
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
