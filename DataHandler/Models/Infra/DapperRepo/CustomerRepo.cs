using Dapper;
using DataHandler.Models.Dtos;
using DataHandler.Models.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataHandler.Models.Infra.DapperRepo
{
	public class CustomerRepo : ICustomerRepo
	{
		private string _connStr;
		private IConfiguration _configuration;

		public CustomerRepo(IConfiguration configuration)
		{
			_configuration = configuration;
			_connStr = _configuration.GetConnectionString("NorthwindContext");
		}

		public IEnumerable<CustmerDto> GetCustmersOrdersInfo(string customerId) 
		{
			string sql = @"SELECT C.[CustomerID],C.[Country],
	   O.OrderDate,
	   OD.UnitPrice,
	   E.[Title],E.LastName 
FROM Customers AS C
JOIN Orders AS O ON O.CustomerID=C.CustomerID
JOIN Employees AS E ON E.EmployeeID=O.EmployeeID
JOIN [Order Details] AS OD ON OD.OrderID=O.OrderID
WHERE C.CustomerID=@customerId;";
			using IDbConnection connection = new SqlConnection(_connStr);
			var result = connection.Query<CustmerDto>(sql, new { customerId = customerId });
			return result;
		}
	}
}
