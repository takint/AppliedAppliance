using Application.Common.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public class PandaDocsController : ApiControllerBase
    {
        private readonly IPandaDocService pandaDocService;

        public PandaDocsController(IPandaDocService pandaDocService)
        {
            this.pandaDocService = pandaDocService;
        }

        // GET: api/<PandaDocController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PandaDocController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PandaDocController>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await pandaDocService.IssuePandaDocDocument(0, PandaDocTemplateType.CLOA);
            return Ok();
        }

        // PUT api/<PandaDocController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PandaDocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
