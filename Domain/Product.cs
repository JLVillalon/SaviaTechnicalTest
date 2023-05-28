using Domain.Interfaces;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PartNumber { get; set; }
        public double Price { get; set; }
    }
}
