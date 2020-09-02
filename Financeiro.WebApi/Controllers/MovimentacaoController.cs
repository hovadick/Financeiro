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
    public class MovimentacaoController : ControllerBase
    {

        private readonly FinanceiroContext _context;
        private readonly IRepository _repo;

        public MovimentacaoController(FinanceiroContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;

        }


        // GET: api/<MovimentaçãoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Movimentacao);
        }


        // GET api/<MovimentacaoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<Movimentacao> query = _context.Movimentacao;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdMvto)
                         .Where(vw => vw.IdMvto == id);
            return Ok(query);
        }

       [HttpGet("")]
        [Route("PorPessoaPorMes")]
        public IActionResult GetPorPessoaPorMes(DateTime dateIni, DateTime dateFim, int idPessoa)
        {
            IQueryable<Movimentacao> query = _context.Movimentacao;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdMvto)
                         .Where(vw => vw.DtCompetencia >= dateIni)
                         .Where(vw => vw.DtCompetencia <= dateFim)
                         .Where(vw => vw.IdPessoa >= idPessoa);
            return Ok(query);
        }


        // GET api/<MovimentacaoController>/5
        [HttpGet("")]
        [Route("PorCategoria")]
        public IActionResult GetCategoria(int IdSubCategoria, int idPessoa)
        {
            IQueryable<Movimentacao> query = _context.Movimentacao;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdMvto)
                         .Where(vw => vw.IdSubCategoria >= IdSubCategoria)
                         .Where(vw => vw.IdPessoa >= idPessoa);
            return Ok(query);
        }


        // POST api/<MovimentaçãoController>
        [HttpPost]
        public IActionResult Post(Movimentacao movimentacao)
        {
            _repo.Add(movimentacao);
            if (_repo.SaveChanges())
            {
                return Ok(movimentacao);
            }

            return BadRequest("Movimentação não cadastrada");
        }

        // PUT api/<MovimentaçãoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Movimentacao movimentacao)
        {
            var mov = _context.Movimentacao.AsNoTracking().FirstOrDefault(a => a.IdMvto == id);
            if (mov == null) return BadRequest("Movimentação não encontrada");

            _repo.Update(movimentacao);
            if (_repo.SaveChanges())
            {
                return Ok(movimentacao);
            }

            return BadRequest("Movimentação não Atualizado");

        }


        // PUT api/<MovimentaçãoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Movimentacao movimentacao)
        {
            var mov = _context.Movimentacao.AsNoTracking().FirstOrDefault(a => a.IdMvto == id);
            if (mov == null) return BadRequest("Movimentação não encontrada");

            _repo.Update(movimentacao);
            if (_repo.SaveChanges())
            {
                return Ok(movimentacao);
            }

            return BadRequest("Movimentação não Atualizado");

        }

        // DELETE api/<MovimentaçãoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mov = _context.Movimentacao.AsNoTracking().FirstOrDefault(a => a.IdMvto == id);
            if (mov == null) return BadRequest("Movimentação não encontrada");

            _repo.Delete(mov);
            if (_repo.SaveChanges())
            {
                return Ok("Movimentação Deletado");
            }

            return BadRequest("Movimentação não Atualizado");
        }
    }
}
