using System.ComponentModel.DataAnnotations;

namespace BazarCore.Data.Repository.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
