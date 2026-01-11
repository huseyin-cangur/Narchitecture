

using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Fuel : Entity<Guid>
    {
        public string Name { get; set; }


        public ICollection<Car>? Cars { get; set; }

        public Fuel()
        {
            Cars = new HashSet<Car>();
        }

        public Fuel(Guid id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }

}