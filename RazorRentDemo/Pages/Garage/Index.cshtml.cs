using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentDemo.Data;
using RazorRentDemo.Model;

namespace RazorRentDemo.Pages.Garage
{
    public class IndexModel : PageModel
    {
        private readonly RazorRentDemo.Data.RentDbContext _context;

        public IndexModel(RazorRentDemo.Data.RentDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car.ToListAsync();
            }
        }
    }
}
