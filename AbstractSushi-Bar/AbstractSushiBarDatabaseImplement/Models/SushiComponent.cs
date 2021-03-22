using System.ComponentModel.DataAnnotations;

namespace AbstractSushiBarDatabaseImplement.Models
{
    public class SushiComponent
    {
        public int Id { get; set; }
        public int SushiId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Sushi Sushi { get; set; }
    }
}
