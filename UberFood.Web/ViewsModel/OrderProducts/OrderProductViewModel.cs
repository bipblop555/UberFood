using System.ComponentModel;

namespace UberFood.Web.ViewsModel.OrderProducts
{
    public class OrderProductViewModel
    {
        [DisplayName("Nom du Produit")]
        public string ProductName { get; set; } = string.Empty;
        [DisplayName("Prix du Produit")]
        public double ProductPrice { get; set; }

    }
}
