

using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Transmission : Entity<Guid>
    {
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public Transmission()
        {
            Cars = new HashSet<Car>();
        }

        public Transmission(Guid id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }

}