using BazarCore.Entities;
using BazarCore.Utils;

namespace BazarCore.Models.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO() { }
        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Icon = category.Icon;
            CountEvents = category.Events?.Count ?? 0;
            CreatedAt = category.CreatedAt.FormatDateToHumanReadable();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? CountEvents { get; set; }
        public string CreatedAt { get; set; }
    }
    public class SimpleCategoryDTO
    {
        public SimpleCategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
