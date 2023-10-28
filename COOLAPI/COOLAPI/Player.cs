namespace COOLAPI
{
    public class Player : IEntity
    {
        public long? Id { get; set; }
        public required string Name { get; set; }
        public required int Level { get; set; }
    }
}
