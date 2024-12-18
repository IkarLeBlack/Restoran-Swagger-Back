using System.ComponentModel.DataAnnotations;

namespace QQQQ
{
    

    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        public OrderEntity? Event { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }  
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }

        
    }
}
