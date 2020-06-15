namespace FakeApplication.Repository.Entities
{
    public class AnchorRE : IRepositoryEntity
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}