using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentDemo.Data;
using RazorRentDemo.Model;

namespace RazorRentDemo.Pages.Rent
{
    public class ReturnModel : PageModel
    {
        public IList<Reservation> Reservations { get; set; } = default!;

        private readonly RentDbContext _context;
        public ReturnModel(RentDbContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            Reservations = _context
                .Reservations
                .Include(c => c.Car)
                .Where(r => r.End == DateTime.MinValue)
                .ToList();
        }
    }
}
