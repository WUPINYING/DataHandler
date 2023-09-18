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
	}
}
