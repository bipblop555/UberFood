using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class DrinkDto : ProductDto
{
    public bool IsFizzy { get; set; }
    public double KCal { get; set; }
    public int Id { get; set; }
}
