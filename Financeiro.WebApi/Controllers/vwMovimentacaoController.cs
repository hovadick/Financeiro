using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Financeiro;
using Financeiro.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vwMovimentacaoController : ControllerBase
    {

        private readonly FinanceiroContext _context;
        private readonly IRepository _repo;

        public vwMovimentacaoController(FinanceiroContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;

        }


        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get(DateTime dataini, DateTime datafim)
        {

            IQueryable<VwMovimentacao> query = _context.VwMovimentacao;


            query = query.AsNoTracking()
                         .OrderBy(vw => vw.DataMovimentação)
                         .Where(vw => vw.Competência == dataini);
                         //.Where(vw => vw.Competência <= datafim);
                         
             return Ok(query);
        }



        // GET api/<vwMovimentacaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<vwMovimentacaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<vwMovimentacaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<vwMovimentacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
