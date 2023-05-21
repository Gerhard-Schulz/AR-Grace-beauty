using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AR_Grace_beauty.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        public decimal Price { get; set; }
    }
}
