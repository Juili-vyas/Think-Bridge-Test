
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public static IActionResult GetInvoice()
        {
            List<Item> items = null;
            if (items.Count == 0) // NullReferenceException
            {
                //return Ok(new { items });
                return NullReferenceException("No Invoice Found");
            }
            return Ok(new { items });
        }

        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }
}
