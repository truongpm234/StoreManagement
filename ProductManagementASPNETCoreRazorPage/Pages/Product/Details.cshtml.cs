using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccessLayer;
using Services;

namespace ProductManagementASPNETCoreRazorPage.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.MyStoreContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public DetailsModel(MyStoreContext context, IProductService productService, ICategoryService categoryService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
        }

        
        public BusinessObject.Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
