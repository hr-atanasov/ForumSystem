namespace ForumSystem.Data.Common.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseModel : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}
