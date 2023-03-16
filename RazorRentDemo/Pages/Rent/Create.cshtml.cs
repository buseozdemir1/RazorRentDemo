using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRentDemo.Data;
using RazorRentDemo.Model;

namespace RazorRentDemo.Pages.Rent
{
    public class CreateModel : PageModel
    {
        public Car Car { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public int CarId { get; set; }


        private readonly RentDbContext _context;
        public CreateModel(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Car = _context.Car.Find(id);

            if (Car == null) return NotFound();

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var carGarage = _context.Car.Find(CarId);

            if (carGarage != null)
            {

                carGarage.Avaliable = false;
                _context.Car.Update(carGarage);

                Reservation res = new();
                res.Car = carGarage;
                res.Start = DateTime.Now;
                res.CustomerName = CustomerName;
                _context.Reservations.Add(res);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
