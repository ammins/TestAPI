using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestAPI.Service;

namespace TestAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ProductService _productService;

		public ProductController( IConfiguration configuration,ProductService pservice)
		{
			_configuration= configuration;
			_productService= pservice;
		}
		[HttpGet]
		public string TestMethod()
		{

			return "Welcome to API";
		}

		[HttpGet]
		public async Task<IActionResult> GetProductList()
		{
			DataTable dt =await  _productService.GetProductList();
			return Ok(dt);
		}


	}
}
