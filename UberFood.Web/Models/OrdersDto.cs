namespace UberFood.Web.Models;

public class OrdersDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int Status { get; set; }
    public OrderProductDto OrderProducts { get; set; } = null!;
}
