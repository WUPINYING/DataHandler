using DataHandler.Models.Dtos;

namespace DataHandler.Models.Interface
{
	public interface ICustomerRepo
	{
		IEnumerable<CustmerDto> GetCustmersOrdersInfo(string customerId);
	}
}
