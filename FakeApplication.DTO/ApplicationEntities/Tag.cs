using FakeApplication.DTO.ApplicationEntities.Interfaces;

namespace FakeApplication.DTO.ApplicationEntities
{
    public class Tag : ICoordinate
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int SignalFrequency { get; set; }
        public bool IsActive { get; set; }
    }
}