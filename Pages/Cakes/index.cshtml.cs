using Dot6.Razor.Crud.Demo.Data;
using Dot6.Razor.Crud.Demo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace Dot6.Razor.Crud.Demo.Pages.Cakes;

public class IndexModel : PageModel
{
    private readonly MyWorldDbContext _myWorldDbContext;
    public IndexModel(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }

    public List<Cake> AllCakes = new List<Cake>();

    public async Task<IActionResult> OnGetAsync()
    {
        AllCakes = await _myWorldDbContext.Cake.ToListAsync();
        return Page();
    }
}