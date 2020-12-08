using System;
using SuperMarket.Models;

namespace SuperMarket.ValidacaoDTO
{
    public class SaidaDTO
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public float ValorDaVenda { get; set; }
        public DateTime Data { get; set; }
    }
}