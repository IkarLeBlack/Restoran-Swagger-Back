using System.ComponentModel.DataAnnotations;

namespace QQQQ
{
   

    public class DishEntity
    {
        [Key]
        public int DishId { get; set; }
        
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int PreparationTime { get; set; } 
        public string PhotoUrl { get; set; } 
    }
}
