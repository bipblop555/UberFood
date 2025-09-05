using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class OrdersDto
{
    private DateTime deliverydate;

    public OrdersDto(DateTime orderdate, DateTime deliverydate, int status, int id)
    {
        this.OrderDate = orderdate;
        this.DelivryDate = deliverydate;
        this.Status = status;
        this.Id = id;
    }

    public OrdersDto(int userId, int AdressId, DateTime orderdate, DateTime deliverydate, int status)
    {
        UserId = userId;
        this.AdressId = AdressId;
        OrderDate = orderdate;
        this.deliverydate = deliverydate;
        Status = status;
    }

    public OrdersDto(int userId, int AdressId, DateTime orderdate, DateTime deliverydate, int status, int id)
    {
        this.UserId = userId;
        this.AdressId = AdressId;
        this.OrderDate = orderdate;
        this.DelivryDate = deliverydate;
        this.Status = status;
        this.Id = id;
    }
    public int UserId { get; set; }
    public int AdressId { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime DelivryDate { get; set; }
    public int Status { get; set; }
    public int Id { get; set; }

    public OrderProductDto OrderProduct { get; set; }
}
