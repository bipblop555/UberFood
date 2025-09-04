using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;
    public sealed class PastaDto : FoodDto
    {
        public PastaDto( string type, double kcal, bool vegetarian,bool alergene,string name,double price,int id )
        : base( vegetarian,alergene,name,price,id)
    {
        this.Type = type;
        this.KCal = kcal;
    }
        public string Type { get; set; }
        public double KCal { get; set; }

    
}

