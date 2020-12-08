using System.ComponentModel.DataAnnotations;
using SuperMarket.Models;

namespace SuperMarket.ValidacaoDTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [MinLength(2, ErrorMessage="Nome inválido.")]
        [StringLength(100, ErrorMessage="Nome do fornecedor excedeu o limite de tamanho maximo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        public int ProdutoId { get; set; }

        [Range(1, 100, ErrorMessage="Valor inválido.")]
        [Required(ErrorMessage="Campo obrigatório.")]
        public float PorcentagemDesconto { get; set; }
    }
}