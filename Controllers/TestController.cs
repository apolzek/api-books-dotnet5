using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace BooksApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IBookstoreDatabaseSettings _settings;
        // private readonly BookService _bookService;

        public TestController(ILogger<TestController> logger, IBookstoreDatabaseSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpGet("LoggingLevels")]
        public ActionResult<string> LoggingLevels()
        {
            _logger.LogInformation("LogInformation => Controller: TestController");
            _logger.LogCritical("LogCritical => Controller: TestController");
            _logger.LogError("LogError => Controller: TestController");
            _logger.LogDebug("LogDebug => Controller: TestController");
            _logger.LogWarning("LogDebug => Controller: TestController");

            return "api-books logging-levels";
        }

        [HttpGet("Hello")]
        public ActionResult<string> Hello(string name)
        {
            return "Hello " + name;
        }

        [HttpGet("GetAllHeaders")]
        public ActionResult<Dictionary<string, string>> GetAllHeaders()
        {
            Dictionary<string, string> requestHeaders =
                new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
            return requestHeaders;
        }

        [HttpGet("QueryString")]
        public IActionResult QueryString([FromQuery(Name = "querystring")] string querystring)
        {
            return Ok("query testing: " + querystring);
        }


        [HttpGet("SumNumbers")]
        public IActionResult SumNumbers(int num1, int num2)
        {
            return Ok(num1 + num2);
        }

        [HttpGet("ConnectionString")]
        public ActionResult<string> ConnectionString()
        {
            return _settings.ConnectionString;
        }

    }
}
