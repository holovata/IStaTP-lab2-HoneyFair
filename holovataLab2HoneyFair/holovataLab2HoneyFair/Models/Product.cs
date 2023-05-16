using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace holovataLab2HoneyFair.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Ціна (грн/упаковка)")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Кількість (кг/упаковка)")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Тип")]
        public int HoneyTypeId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Регіон збору")]
        public int HoneyRegionId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Постачальник")]
        public int DealerId { get; set; }
        public virtual HoneyRegion HoneyRegion { get; set; }
        public virtual HoneyType HoneyType { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
