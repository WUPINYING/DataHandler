using DataHandler.Models.Dtos;
using DataHandler.Models.Interface;

namespace DataHandler.Models.Services
{

	public class CustomerService
	{
		private ICustomerRepo _repo;

		public CustomerService(ICustomerRepo repo)
		{
			_repo = repo;
		}

		public IEnumerable<CustmerDto> GetCustmerOrderInfo(string customerId)
		{
			var result = _repo.GetCustmersOrdersInfo(customerId);
			return result;
		}
	}
}
