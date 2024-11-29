using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace newExam.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly AppDbContext _context;

        public StatisticModel(AppDbContext context)
        {
            _context = context;
        }

        public int complitedOrdersCount { get; set; }
        public double avgCompleteOrderTime { get; set; }
        public Dictionary<string, int> problemStats { get; set; } = new();

        public async Task OnGetAsync()
        {
            //Количество выполненных заявок
            complitedOrdersCount = await _context.Orders
                .CountAsync(o => o.complitedDate != null);

            //Среднее время выполнения заявки
            avgCompleteOrderTime = _context.Orders
                .Where(o => o.complitedDate != null)
                .AsEnumerable() 
                .Select(o => o.complitedDate.Value.DayNumber - o.addedDate.DayNumber)
                .Average();


            //Статистика по типам
            problemStats = await _context.Orders
                .GroupBy(o => o.description.ToLower())
                .Select(group => new { ProblemType = group.Key, Count = group.Count() })
                .ToDictionaryAsync(g => g.ProblemType, g => g.Count);
        }
    }
}

