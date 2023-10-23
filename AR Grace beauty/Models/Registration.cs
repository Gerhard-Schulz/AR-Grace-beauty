using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalanjBarberShop.Models;

public class Registration
{
    [Key]
    public int Id { get; set; }

    [DisplayName("Дата и время записи")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public DateTime DateTime { get; set; }

    [DisplayName("Продолжительность приёма")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public decimal Length { get; set; }

    [DisplayName("Клиент")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public int ClientId { get; set; }
    [ValidateNever]
    [ForeignKey("ClientId")]
    public Client Client { get; set; }

    [DisplayName("Мастер")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public int WorkerId { get; set; }
    [ValidateNever]
    [ForeignKey("WorkerId")]
    public Worker Worker { get; set; }

    [DisplayName("Услуга")]
    [Required(ErrorMessage = "Это поле обязательно к заполнению")]
    public int TypeServiceId { get; set; }
    [ValidateNever]
    [ForeignKey("TypeServiceId")]
    public TypeService TypeService { get; set; }
}
