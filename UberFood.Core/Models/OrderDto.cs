using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class OrderDto
{
    public DateTime OrderDate { get; set; }
    public DateTime DelivryDate { get; set; }
    public int Status { get; set; }
}
