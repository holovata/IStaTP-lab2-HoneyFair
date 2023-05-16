using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace holovataLab2HoneyFair.Models
{
    public class FairLocation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Місто")]
        public string City { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Адреса")]
        public string Address { get; set; }
    }
}
