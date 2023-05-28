
using Domain.Interfaces;

namespace Domain
{
    public class BaseEntity : IId
    {
        public Guid Id { get; set; }
    }
}
