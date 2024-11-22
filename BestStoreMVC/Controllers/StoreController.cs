using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly int pageSize = 8;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pageIndex, string? search, string? brand, string? catrgory, string? sort)
        {
            IQueryable<Product> query = _context.Products;

            // Search functionality
            if (search !=  null && search.Length > 0)
            {
                query = query.Where(p => p.Name.Contains(search));
            }

            // Filter functionality
            if (brand != null && brand.Length > 0)
            {
                query = query.Where(p => p.Name.Contains(brand));
            }

            if (catrgory != null && catrgory.Length > 0)
            {
                query = query.Where(p => p.Name.Contains(catrgory));
            }

            // Sort functionality
            if (sort == "price_asc")
            {
                query = query.OrderBy(p => p.Price);
            }
            else if (sort == "price_desc")
            {
                query = query.OrderByDescending(p => p.Price);
            }
            else
            {
                // Newest products first
                query = query.OrderByDescending(p => p.Id);
            }

            // Pagination functionality
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            decimal count = query.Count();
            int totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var products = query.ToList();

            ViewBag.Products = products;
            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = totalPages;

            var storeSearchModel = new StoreSearchModel()
            {
                Search = search,
                Brand = brand,
                Category = catrgory,
                Sort = sort
            };

            return View(storeSearchModel);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Store");
            }

            return View(product);
        }
    }
}
