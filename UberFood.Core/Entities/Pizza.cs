using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class Pizza : Food
{
    public int DoughId { get; set; }
    public Dough Dough { get; set; }

    public List<Ingredient> Ingredients { get; set; }
}
