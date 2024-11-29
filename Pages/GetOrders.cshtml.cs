using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace newExam.Pages
{
    [IgnoreAntiforgeryToken]
    public class GetOrdersModel : PageModel
    {
        private readonly AppDbContext _context;

        public GetOrdersModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int searchNumber { get; set; }
        public Order? searchedOrder { get; set; }
        public List<Order> Orders { get; set; } = new();

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            searchedOrder = await _context.Orders.FirstOrDefaultAsync(o => o.number == searchNumber);
            if (searchedOrder == null)
                return NotFound($"Заявка номер {searchNumber} не найдена");

            return Page();
        }
    }
}
