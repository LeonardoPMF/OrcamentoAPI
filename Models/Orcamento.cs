using System;

namespace API.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int Categoria { get; set; }
        public string Descricao { get; set; }
        
    }
}
