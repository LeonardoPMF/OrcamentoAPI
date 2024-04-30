using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public OrcamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterOrcamentos()
        {
            var orcamentos = _context.Orcamentos.ToList();
            return Ok(orcamentos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterOrcamentoPorId(int id)
        {
            var orcamento = _context.Orcamentos.Find(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return Ok(orcamento);
        }

        [HttpPost]
        public IActionResult CriarOrcamento(Orcamento novoOrcamento)
        {
            _context.Orcamentos.Add(novoOrcamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterOrcamentoPorId), new { id = novoOrcamento.Id }, novoOrcamento);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarOrcamento(int id, Orcamento orcamentoAtualizado)
        {
            var orcamento = _context.Orcamentos.Find(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            // Atualizando as propriedades
            orcamento.Nome = orcamentoAtualizado.Nome;
            orcamento.Valor = orcamentoAtualizado.Valor;
            orcamento.Data = orcamentoAtualizado.Data;
            orcamento.Descricao = orcamentoAtualizado.Descricao;
            orcamento.Categoria = orcamentoAtualizado.Categoria;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirOrcamento(int id)
        {
            var orcamento = _context.Orcamentos.Find(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            _context.Orcamentos.Remove(orcamento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
