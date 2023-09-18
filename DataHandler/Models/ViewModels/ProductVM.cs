namespace DataHandler.Models.ViewModels
{
	public class ProductVM
	{
		public string ProductName { get; set; }

		public string QuantityPerUnit { get; set; }

		public decimal? UnitPrice { get; set; }

		public bool Discontinued { get; set; }
	}
}
