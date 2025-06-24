using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccessLayer;
using Services;
using Microsoft.AspNetCore.SignalR;
using SignalRLab;

namespace ProductManagementASPNETCoreRazorPage.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessLayer.MyStoreContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHubContext<SignalrServer> _hubContext;
        public CreateModel(MyStoreContext context, IProductService productService, ICategoryService categoryService, IHubContext<SignalrServer> hubContext)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Product.Category");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.SaveProduct(Product);
            await _hubContext.Clients.All.SendAsync("LoadAllItems");
            return RedirectToPage("./Index");
        }
    }
}
