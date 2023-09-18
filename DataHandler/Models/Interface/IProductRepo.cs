using DataHandler.Models.Dtos;

namespace DataHandler.Models.Interface
{
	public interface IProductRepo
	{
		void CreateProduct(ProductDto dto);
	};
}
