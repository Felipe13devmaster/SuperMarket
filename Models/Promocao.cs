namespace SuperMarket.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Produto Produto { get; set; }
        public float PorcentagemDesconto { get; set; }
        public bool Status { get; set; }
    }
}