

using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity<Guid>
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public Brand? Brand { get; set; }

        public ICollection<Car>? Cars { get; set; }

        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public Model(Guid id, Guid brandId, string name, decimal dailyPrice, string imageUrl) : this()
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }

    }

}