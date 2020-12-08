using System;

namespace SuperMarket.ValidacaoDTO
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public float ValorPago { get; set; }
        public float ValorTroco { get; set; }
    }
}