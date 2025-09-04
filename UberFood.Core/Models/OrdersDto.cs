using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class OrdersDto
{
    public OrdersDto(DateTime orderdate, DateTime deliverydate,int status,int id) 
    {
        this.OrderDate = orderdate;
        this.DelivryDate = deliverydate;
        this.Status = status;
        this.Id = id;
    }
    public DateTime OrderDate { get; set; }
    public DateTime DelivryDate { get; set; }
    public int Status { get; set; }
    public int Id { get; set; }
}
