using System.ComponentModel.DataAnnotations.Schema;

namespace Pinewood.CustomerManagement.Core.Entities
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
