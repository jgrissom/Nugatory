using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nugatory.Models;
using Swashbuckle.AspNetCore.Annotations;

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
        [HttpGet, SwaggerOperation(summary: "returns all words", null)]
        public IEnumerable<WordColor> Get()
        {
            return _dataContext.WordColors;
        }
        [HttpGet("{id}"), SwaggerOperation(summary: "returns specific word", null)]
        public WordColor Get(int id)
        {
            return _dataContext.WordColors.Find(id);
        }
        [HttpPost, SwaggerOperation(summary: "add word to collection", null), ProducesResponseType(typeof(WordColor), 201), SwaggerResponse(201, "Created")]
        // add event
        public WordColor Post([FromBody] WordColor wordColor) => _dataContext.AddWord(new WordColor
        {
            Word = wordColor.Word,
            Color = wordColor.Color
        });
        [HttpDelete("{id}"), SwaggerOperation(summary: "delete score from collection", null), ProducesResponseType(typeof(WordColor), 204), SwaggerResponse(204, "No Content")]
        public ActionResult Delete(int id){
            WordColor wc = _dataContext.WordColors.Find(id);
            if (wc == null){
                return NotFound();
            }
            _dataContext.DeleteWord(id);
            return NoContent();
        } 
    }
}
