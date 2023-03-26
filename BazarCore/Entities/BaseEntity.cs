using BazarCore.Data.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BazarCore.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
