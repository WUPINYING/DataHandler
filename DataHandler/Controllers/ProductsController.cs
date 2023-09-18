using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataHandler.Models;
using DataHandler.Models.ViewModels;
using DataHandler.Models.Exts;
using DataHandler.Models.Services;
using DataHandler.Models.Interface;
using DataHandler.Models.Dtos;

namespace DataHandler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly NorthwindContext _db;
		private readonly IProductRepo _repo;

		public ProductsController(NorthwindContext db, IProductRepo repo)
		{
			_db = db;
			_repo = repo;
		}

		// GET: api/Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
		{
			if (_db.Products == null)
			{
				return NotFound();
			}
			return await _db.Products.ToListAsync();
		}

		// PUT: api/Products/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, ProductDto dto)
		{
			Products existingProduct = await _db.Products.FindAsync(id);

			if (existingProduct == null)
			{
				return BadRequest("找不到商品");
			}

			var service = new ProductService(_repo);
			service.UpdateProduct(dto);

			return Ok("商品編輯成功");
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<ProductVM>> CreateProduct(ProductVM vm)
		{
			var service = new ProductService(_repo);
			service.CreateProduct(vm.ToDto());

			return Ok("商品新增成功");
		}

		// DELETE: api/Products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProducts(int id)
		{
			bool hasPro = ProductsExists(id);
			if (hasPro == false)
			{
				return Ok("商品刪除失敗");
			}
			else
			{
				var service = new ProductService(_repo);
				service.DeleteProduct(id);
				return Ok("商品刪除成功");
			}
		}

		private bool ProductsExists(int id)
		{
			return (_db.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
		}
	}
}
