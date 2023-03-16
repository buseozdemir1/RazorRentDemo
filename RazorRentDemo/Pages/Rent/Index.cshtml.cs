using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentDemo.Data;
using RazorRentDemo.Model;

namespace RazorRentDemo.Pages.Rent
{
    public class IndexModel : PageModel
    {
        public IList<Car> Cars { get; set; } = default!;

        private readonly RentDbContext _context;
        public IndexModel(RentDbContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                //Cars = await _context.Car.Where(c => c.Avaliable == true).ToListAsync();
                Cars = await _context.Car.ToListAsync();
            }
        }
    }
}
