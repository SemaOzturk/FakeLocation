namespace FakeApplication.Repository.Entities
{
    public class TagRE : IRepositoryEntity
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int SignalFrequency { get; set; }
        public bool IsActive { get; set; }
    }
}