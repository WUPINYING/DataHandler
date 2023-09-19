using DataHandler.Models.Dtos;
using DataHandler.Models.Interface;

namespace DataHandler.Models.Services
{
	
	public class ProductService
	{
		private IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
			_repo = repo;
        }

        public void CreateProduct(ProductDto dto)
		{
			_repo.CreateProduct(dto);
		}

		public ProductDto UpdateProduct(int id, ProductDto dto) 
		{
			ProductDto newProductDto = _repo.UpdateProduct( id, dto);
			return newProductDto;
		}

		public void DeleteProduct(int id)
		{
			_repo.DeleteProduct(id);
		}
	}
}
