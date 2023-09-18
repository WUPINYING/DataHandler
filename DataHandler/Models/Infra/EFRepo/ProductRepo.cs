using DataHandler.Models.Dtos;
using DataHandler.Models.Interface;

namespace DataHandler.Models.Infra.EFRepo
{
	public class ProductRepo : IProductRepo
	{
		private readonly NorthwindContext _db;
		public ProductRepo(NorthwindContext db)
		{
			_db = db;
		}

		public void CreateProduct(ProductDto dto)
		{
			Products products = new Products
			{				
				ProductName = dto.ProductName,
				QuantityPerUnit = dto.QuantityPerUnit,
				UnitPrice = dto.UnitPrice,
				Discontinued= dto.Discontinued
			};

			_db.Add(products);
			_db.SaveChangesAsync();
		}

		public ProductDto UpdateProduct(ProductDto dto)
		{
			Products newProductDto = new Products
			{
				ProductName = dto.ProductName,
				QuantityPerUnit = dto.QuantityPerUnit,
				UnitPrice = dto.UnitPrice,
				Discontinued = dto.Discontinued
			};

			_db.Add(newProductDto);
			_db.SaveChangesAsync();

			ProductDto resultDto = new ProductDto
			{
				ProductName = newProductDto.ProductName,
				QuantityPerUnit = newProductDto.QuantityPerUnit,
				UnitPrice = newProductDto.UnitPrice,
				Discontinued = newProductDto.Discontinued
			};

			return resultDto;
		}
		
		public void DeleteProduct(int id)
		{
			var product = _db.Products.Find(id);
			if (product != null)
			{
				_db.Products.Remove(product);
				_db.SaveChanges();
			}
		}
	}
}
