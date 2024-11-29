using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace newExam.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditOrderModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditOrderModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingOrder = await _context.Orders.FirstOrDefaultAsync(o => o.number == Order.number);
            if (existingOrder == null)
                return NotFound($"Заявка номер {Order.number} не найдена.");

            existingOrder.description = Order.description == null ? existingOrder.description : Order.description;
            existingOrder.master = Order.master == null ? existingOrder.master : Order.master;
            existingOrder.stage = Order.stage == null ? existingOrder.stage : Order.stage;
            existingOrder.status = Order.status == null ? existingOrder.status : Order.status;
            existingOrder.masterComment = Order.masterComment;

            await _context.SaveChangesAsync();

            TempData["Message"] = $"Статус заявки номер {existingOrder.number} был изменён.";
            if (existingOrder.status == "завершена" )
            {
                TempData["Message"] = $"Заявка с номером {existingOrder.number} завершена.";
                existingOrder.complitedDate = DateOnly.FromDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
            }
            else
            {
                existingOrder.complitedDate = null;
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
