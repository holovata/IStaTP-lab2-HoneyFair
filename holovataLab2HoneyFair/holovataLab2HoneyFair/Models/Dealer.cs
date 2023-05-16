using System.ComponentModel.DataAnnotations;

namespace holovataLab2HoneyFair.Models
{
    public class Dealer
    {
        public Dealer() 
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name="Постачальник")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
