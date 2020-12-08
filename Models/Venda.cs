using System;

namespace SuperMarket.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public float ValorPago { get; set; }
        public float ValorTroco { get; set; }
    }
}