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

namespace ProductManagementASPNETCoreRazorPage.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessLayer.MyStoreContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CreateModel(MyStoreContext context, IProductService productService, ICategoryService categoryService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
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

            return RedirectToPage("./Index");
        }
    }
}
