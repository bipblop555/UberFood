using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Ingredients;

    public class IngredientsViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Kilo Calories")]
        public double KCal { get; set; }
    
    }
