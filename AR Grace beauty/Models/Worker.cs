using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AR_Grace_beauty.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        public string Name { get; set; }

        [DisplayName("Номер телефона")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        public string Phone { get; set; }

        [DisplayName("Должность")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        public string Phost { get; set; }
    }
}
