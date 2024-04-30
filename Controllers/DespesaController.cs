using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController : ControllerBase
    {
        // Exemplo de uma lista de despesas como um banco de dados em memória
        private static List<Despesa> despesas = new List<Despesa>();

        // [HttpGet] para buscar todas as despesas
        [HttpGet]
        public IActionResult ObterDespesas()
        {
            return Ok(despesas);
        }

        // [HttpGet("{id}")] para buscar uma despesa por ID
        [HttpGet("{id}")]
        public IActionResult ObterDespesaPorId(int id)
        {
            var despesa = despesas.FirstOrDefault(d => d.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }
            return Ok(despesa);
        }

        // [HttpPost] para criar uma nova despesa
        [HttpPost]
        public IActionResult CriarDespesa(Despesa novaDespesa)
        {
            despesas.Add(novaDespesa);
            return CreatedAtAction(nameof(ObterDespesaPorId), new { id = novaDespesa.Id }, novaDespesa);
        }

        // [HttpPut("{id}")] para atualizar uma despesa existente
        [HttpPut("{id}")]
        public IActionResult AtualizarDespesa(int id, Despesa despesaAtualizada)
        {
            var despesa = despesas.FirstOrDefault(d => d.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

            // Atualizando os valores da despesa existente
            despesa.Nome = despesaAtualizada.Nome;
            despesa.Valor = despesaAtualizada.Valor;
            despesa.Data = despesaAtualizada.Data;

            return NoContent();
        }

        // [HttpDelete("{id}")] para excluir uma despesa por ID
        [HttpDelete("{id}")]
        public IActionResult ExcluirDespesa(int id)
        {
            var despesa = despesas.FirstOrDefault(d => d.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

            despesas.Remove(despesa);
            return NoContent();
        }
    }
}
