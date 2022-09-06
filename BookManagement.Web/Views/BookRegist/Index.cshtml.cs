using BookManagement.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookManagement.Web.BookManagementDbContext _context;

        public IndexModel(BookManagement.Web.BookManagementDbContext context)
        {
            _context = context;
        }

        public IList<Register> Register { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Register != null)
            {
                Register = await _context.Register.ToListAsync();
            }
        }
    }
}
