using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEntityFramworkMVCeShopApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price cannot be empty")]
        [Range(1, Double.MaxValue, ErrorMessage = "Invalid price value")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid quantity value")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Brand name cannot be empty")]
        public string BrandName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Manufactring date cannot be empty")]
        public DateTime ManufactringDate { get; set; }

        [Display(Name ="Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
    }
}
