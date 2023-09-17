namespace DataHandler.Models.ViewModels
{
	public class CustomerVM
	{
		//Customers
		public string CustomerId { get; set; }

		public string Country { get; set; }

		//Orders
		public DateTime? OrderDate { get; set; }

		//OrderDetails
		public decimal UnitPrice { get; set; }

		//Employees
		public string LastName { get; set; }
	}
}
