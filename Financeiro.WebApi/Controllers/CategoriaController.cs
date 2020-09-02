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
    public class CategoriaController : ControllerBase
    {

        private readonly FinanceiroContext _context;
        private readonly IRepository _repo;

        public CategoriaController(FinanceiroContext context, IRepository repo)
        {
            _repo = repo;
            _context = context; 

        }


        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Categoria);
        }

        
        // GET api/<CategoriaController>/5
        [HttpGet]
        [Route("PorPessoa")]
        public IActionResult GetPessoa(int Pessoaid)
        {
            IQueryable<Categoria> query = _context.Categoria;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdCategoria)
                         .Where(vw => vw.IdPessoa == Pessoaid);
            return Ok(query);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<Categoria> query = _context.Categoria;

            query = query.AsNoTracking()
                         .OrderBy(vw => vw.IdCategoria)
                         .Where(vw => vw.IdCategoria == id);
            return Ok(query);
        }



        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            _repo.Add(categoria);
            if (_repo.SaveChanges())
            {
                return Ok(categoria);
            }

            return BadRequest("Categoria não cadastrada");
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {
            var cat = _context.Categoria.AsNoTracking().FirstOrDefault(a => a.IdCategoria == id);
            if (cat == null) return BadRequest("Categoria não encontrada");

            _repo.Update(categoria);
            if (_repo.SaveChanges())
            {
                return Ok(categoria);
            }

            return BadRequest("Categoria não Atualizado");

        }


        // PUT api/<CategoriaController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Categoria categoria)
        {
            var cat = _context.Categoria.AsNoTracking().FirstOrDefault(a => a.IdCategoria == id);
            if (cat == null) return BadRequest("Categoria não encontrada");

            _repo.Update(categoria);
            if (_repo.SaveChanges())
            {
                return Ok(categoria);
            }

            return BadRequest("Categoria não Atualizado");

        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = _context.Categoria.AsNoTracking().FirstOrDefault(a => a.IdCategoria == id);
            if (cat == null) return BadRequest("Categoria não encontrada");

            _repo.Delete(cat);
            if (_repo.SaveChanges())
            {
                return Ok("Categoria Deletado");
            }

            return BadRequest("Categoria não Atualizado");
        }
    }
}
