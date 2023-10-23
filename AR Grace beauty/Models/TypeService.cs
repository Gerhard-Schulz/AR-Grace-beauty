using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GalanjBarberShop.Models;

public class TypeService
{
    [Key]
    public int Id { get; set; }

    [DisplayName("Наименование")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public string Name { get; set; }

    [DisplayName("Цена")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public decimal Price { get; set; }

    [DisplayName("Описание")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public string Description { get; set; }

    [DisplayName("Услуга")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public int ServiceId { get; set; }
    [ValidateNever]
    [ForeignKey("ServiceId")]
    public Service Service { get; set; }

    [NotMapped]
    [ValidateNever]
    [DisplayName("Итоговая цена")]
    public decimal TotalPrice => Price + Service.Price;
}
