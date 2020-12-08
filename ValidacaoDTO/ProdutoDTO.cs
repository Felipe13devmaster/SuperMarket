using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ValidacaoDTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [MinLength(2, ErrorMessage="Nome inválido.")]
        [StringLength(100, ErrorMessage="Nome do fornecedor excedeu o limite de tamanho maximo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        public float PrecoDeCusto { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        public float PrecoDeVenda { get; set; }

        [Range(0, 2, ErrorMessage="Codigo inválido.")]
        [Required(ErrorMessage="Campo obrigatório.")]
        public int UnidadeDeMedida { get; set; }
    }
}