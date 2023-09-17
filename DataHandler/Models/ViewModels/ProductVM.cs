namespace DataHandler.Models.ViewModels
{
	public class ProductVM
	{
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public string QuantityPerUnit { get; set; }

		public decimal? UnitPrice { get; set; }

		public bool Discontinued { get; set; }
	}
}
