using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
