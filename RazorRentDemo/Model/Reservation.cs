using System.ComponentModel.DataAnnotations;

namespace RazorRentDemo.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required, StringLength(50), Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalPrice { get; set; }
        public Car Car { get; set; }

    }
}
