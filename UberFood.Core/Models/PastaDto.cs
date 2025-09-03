using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;
    public class PastaDto : FoodDto
    {
        public string Type { get; set; }
        public double KCal { get; set; }
        public int Id { get; set; }
    }

