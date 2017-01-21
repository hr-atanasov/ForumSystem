using ForumSystem.Data.Common;
using ForumSystem.Data.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    public class Tag : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
     
    }
}
