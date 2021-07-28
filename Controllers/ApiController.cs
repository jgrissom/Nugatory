using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nugatory.Models;

namespace WordApi.Controllers
{
    [ApiController, Route("[controller]/word")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private DataContext _dataContext;

        public ApiController(ILogger<ApiController> logger, DataContext db)
        {
            _dataContext = db;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<WordColor> Get()
        {
            return _dataContext.WordColors;
        }
    }
}