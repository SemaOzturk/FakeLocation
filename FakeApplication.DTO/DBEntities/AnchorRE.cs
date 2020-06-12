namespace FakeApplication.Repository.Entities
{
    public class AnchorRE : IRepositoryEntity
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}