namespace UberFood.Web.Services;

public class OrdersDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int Status { get; set; }
    public List<OrderProductDto> OrderProducts { get; set; } = null!;
}
