namespace DataHandler.Models.Dtos
{
	public class ProductDto
	{
		public int? ProductId { get; set; }

		public string ProductName { get; set; }

		public string QuantityPerUnit { get; set; }

		public decimal? UnitPrice { get; set; }

		public bool Discontinued { get; set; }
	}
}
