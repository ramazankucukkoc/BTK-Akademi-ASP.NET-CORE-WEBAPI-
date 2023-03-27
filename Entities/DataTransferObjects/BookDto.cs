namespace Entities.DataTransferObjects
{
    public record BookDto
    {
        public int ID { get; init; }
        public String Name { get; init; }
        public decimal Price { get; init; }
    }
}
