using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataHandler.Models;
using DataHandler.Models.Interface;
using DataHandler.Models.Services;
using DataHandler.Models.ViewModels;
using DataHandler.Models.Exts;

namespace DataHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NorthwindContext _db; //放到全域變數當中就可以使用了
        private readonly ICustomerRepo _repo;

        public CustomersController(NorthwindContext db,ICustomerRepo repo) //NorthwindContext 物件已被 new 出來，才可以使用 DI
		{
            _db = db;
            _repo = repo;
        }
        //public CustomersController()
        //{
        //    _db = new NorthwindContext();
        //}

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            if (_db.Customers == null)
            {
                return NotFound();
            }
            return await _db.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVM>> GetCustmerOrderInfo(string id)
        {
			var service = new CustomerService(_repo);
			var result = service.GetCustmerOrderInfo(id).Select(C=>C.ToVM());

            if(result.Count() <= 0)
            {
				return Ok("找不到對應資料");
			}

			return Ok(result);
		}
    }
}
