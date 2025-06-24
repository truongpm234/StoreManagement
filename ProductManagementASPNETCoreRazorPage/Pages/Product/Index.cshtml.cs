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
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.MyStoreContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public IndexModel(MyStoreContext context, IProductService productService, ICategoryService categoryService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IList<BusinessObject.Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = _productService.GetProducts();
        }
    }
}
