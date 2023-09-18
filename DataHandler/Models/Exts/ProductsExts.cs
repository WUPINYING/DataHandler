using DataHandler.Models.Dtos;
using DataHandler.Models.ViewModels;

namespace DataHandler.Models.Exts
{
	public static class ProductsExts
	{
        public static ProductDto ToDto(this ProductVM vm)
        {
            return new ProductDto()
            {
                ProductName = vm.ProductName,
                QuantityPerUnit = vm.QuantityPerUnit,
                UnitPrice = vm.UnitPrice,
                Discontinued = vm.Discontinued
            };
        }
    }
}
