using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UberFood.Core.Models;

public class DoughDto
{
    public DoughDto(string name, int id)
    { 
        this.Name = name;
        this.Id = id;
    }
    public string Name { get; set; }
    public int Id { get; set; }
}
