using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorRentDemo.Data;
using RazorRentDemo.Model;
using System.ComponentModel.DataAnnotations;

namespace RazorRentDemo.Pages.Garage
{
    public enum CarState
    {
        [Display(Name = "Avaliable for Rent")]
        Avaliable,
        NotAvaliable,
        Rented
    }

    public class CreateModel : PageModel
    {
        //[BindProperty]
        public CarState CStateEnum { get; set; }

        //[BindProperty]
        public string CStateListSelection { get; set; }

        [BindProperty]
        public string TestText { get; set; }

        public List<SelectListItem> CarStateList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MX", Text = "Avaliable" },
            new SelectListItem { Value = "CA", Text = "NotAvaliable" },
            new SelectListItem { Value = "US", Text = "Rented"  },
        };

        private readonly RentDbContext _context;


        public CreateModel(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            TempData["success"] = "Added succesfully";

            return RedirectToPage("Index");
        }
    }
}
