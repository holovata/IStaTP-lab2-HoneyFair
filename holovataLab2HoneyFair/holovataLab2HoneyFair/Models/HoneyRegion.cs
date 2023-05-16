using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace holovataLab2HoneyFair.Models
{
    public class HoneyRegion
    {
        public HoneyRegion()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Регіон збору")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
