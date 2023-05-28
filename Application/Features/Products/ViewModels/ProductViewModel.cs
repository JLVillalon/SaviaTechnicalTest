
namespace Application.Features.Products.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PartNumber { get; set; }
        public double Price { get; set; }
    }
}
