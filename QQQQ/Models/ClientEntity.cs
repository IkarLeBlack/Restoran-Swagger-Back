using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQQQ
{


    public class ClientEntity
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactInfo { get; set; }
        public string LoyaltyProgram { get; set; }

        public List<OrderEntity>? OrderIds { get; set; }
       
    }

}
