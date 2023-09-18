using DataHandler.Models.Dtos;
using DataHandler.Models.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

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
	}
}
