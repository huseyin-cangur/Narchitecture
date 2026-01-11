

using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Entity<Guid>
    {
        public Guid ModelId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public short MinFindexScore { get; set; }
        public CarState CarState { get; set; }
        public virtual Model? Model { get; set; }
        public virtual Fuel? Fuel { get; set; }
        public virtual Transmission? Transmission { get; set; }

        public Car(Guid id, Guid modelId, Guid transmissionId, Guid fuelId, short modelYear, string plate, short minFindexScore, CarState carState)
        {
            Id = id;
            ModelId = modelId;
            TransmissionId = transmissionId;
            FuelId = fuelId;
            ModelYear = modelYear;
            Plate = plate;
            MinFindexScore = minFindexScore;
            CarState = carState;

        }
    }

}