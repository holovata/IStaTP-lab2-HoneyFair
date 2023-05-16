using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace holovataLab2HoneyFair.Models
{
    public class HoneyType
    {
        public HoneyType()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Тип")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
