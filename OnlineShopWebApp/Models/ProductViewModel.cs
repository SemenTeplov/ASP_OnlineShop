using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000000, ErrorMessage = "Цена должна быть в пределе от 1 до 1 000 000!")]
        [DataType(DataType.Currency, ErrorMessage = "Число")]
        public decimal Coast { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
