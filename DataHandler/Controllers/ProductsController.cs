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
		public async Task<IActionResult> PutProducts(int id, Products products)
		{
			if (id != products.ProductId)
			{
				return BadRequest();
			}

			_db.Entry(products).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductsExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<ProductVM>> CreateProducts(ProductVM vm)
		{
			var service = new ProductService(_repo);
			service.CreateProduct(vm.ToDto());

			return Ok("商品新增成功");
		}

		// DELETE: api/Products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProducts(int id)
		{
			if (_db.Products == null)
			{
				return NotFound();
			}
			var products = await _db.Products.FindAsync(id);
			if (products == null)
			{
				return NotFound();
			}

			_db.Products.Remove(products);
			await _db.SaveChangesAsync();

			return NoContent();
		}

		private bool ProductsExists(int id)
		{
			return (_db.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
		}
	}
}
