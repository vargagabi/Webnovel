using Microsoft.AspNetCore.Mvc;
using Webnovel.Database;
using Webnovel.Models;

namespace Webnovel.Controllers
{
	public class WebnovelController : Controller
	{
		private readonly ApplicationDbContext db;

		public WebnovelController(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{

			IEnumerable<Models.Webnovel> objWebnovelList = db.Webnovels;
			return View(objWebnovelList);
		}
	}
}
