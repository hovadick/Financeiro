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
    public class ContasController : ControllerBase
    {


        private readonly FinanceiroContext _context;
        private readonly IRepository _repo;

        public ContasController(FinanceiroContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;

        }


        // GET: api/<ContaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Conta);
        }


        // GET api/<ContaController>/5
        [HttpGet("{id}")]
        [Route("PorPessoa")]
        public IActionResult getporPessoa(int idPessoa)
        {
            IQueryable<Conta> query = _context.Conta;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.NmConta)
                         .Where(vw => vw.IdPessoa == idPessoa);
            return Ok(query);
        }


        // GET api/<ContaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<Conta> query = _context.Conta;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdConta)
                         .Where(vw => vw.IdConta == id);
            return Ok(query);
        }



        // POST api/<ContaController>
        [HttpPost]
        public IActionResult Post(Conta conta)
        {
            _repo.Add(conta);
            if (_repo.SaveChanges())
            {
                return Ok(conta);
            }

            return BadRequest("Conta não cadastrada");
        }

        // PUT api/<ContaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Conta conta)
        {
            var cat = _context.Conta.AsNoTracking().FirstOrDefault(a => a.IdConta == id);
            if (cat == null) return BadRequest("Conta não encontrada");

            _repo.Update(conta);
            if (_repo.SaveChanges())
            {
                return Ok(conta);
            }

            return BadRequest("Conta não Atualizado");

        }


        // PUT api/<ContaController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Conta conta)
        {
            var cat = _context.Conta.AsNoTracking().FirstOrDefault(a => a.IdConta == id);
            if (cat == null) return BadRequest("Conta não encontrada");

            _repo.Update(conta);
            if (_repo.SaveChanges())
            {
                return Ok(conta);
            }

            return BadRequest("Conta não Atualizado");

        }

        // DELETE api/<ContaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = _context.Conta.AsNoTracking().FirstOrDefault(a => a.IdConta == id);
            if (cat == null) return BadRequest("Conta não encontrada");

            _repo.Delete(cat);
            if (_repo.SaveChanges())
            {
                return Ok("Conta Deletado");
            }

            return BadRequest("Conta não Atualizado");
        }
    }
}
