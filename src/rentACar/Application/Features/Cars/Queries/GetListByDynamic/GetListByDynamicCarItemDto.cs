

namespace Application.Features.Cars.Queries.GetListByDynamic
{
    public class GetListByDynamicCarItemDto
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string FuelName { get; set; }
        public string TransmissionName { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public short MinFindexScore { get; set; }
    }
}