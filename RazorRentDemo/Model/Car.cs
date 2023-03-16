using System.ComponentModel.DataAnnotations;

namespace RazorRentDemo.Model
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Brand { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        public bool Avaliable { get; set; } 

    }
}
