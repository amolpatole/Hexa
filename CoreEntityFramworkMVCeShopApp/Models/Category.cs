using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEntityFramworkMVCeShopApp.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Category name cannot be empty")]
        [MinLength(3, ErrorMessage ="Minimum 3 charachers required")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage ="Maximum 200 characters allowed")]
        public string Description { get; set; }
    }
}
