namespace CqsApi.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderLineDto> Lines { get; set; }
    }

    public class OrderLineDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderInputDto
    {
        public decimal Total { get; set; }
        public IEnumerable<OrderLineDto> Lines { get; set; }
    }

}
