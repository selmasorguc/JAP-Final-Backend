using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}
