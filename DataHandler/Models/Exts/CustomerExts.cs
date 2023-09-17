using DataHandler.Models.Dtos;
using DataHandler.Models.ViewModels;

namespace DataHandler.Models.Exts
{
	public static class CustomerExts
	{
		public static CustomerVM ToVM(this CustmerDto dto)
		{
			return new CustomerVM()
			{
				CustomerId = dto.CustomerId,
				Country = dto.Country,
				OrderDate = dto.OrderDate,
				UnitPrice = dto.UnitPrice,
				LastName = dto.LastName
			};
		}
	}
}
