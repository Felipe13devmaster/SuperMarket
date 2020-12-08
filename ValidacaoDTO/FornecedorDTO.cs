using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ValidacaoDTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [MinLength(2, ErrorMessage="Nome inválido.")]
        [StringLength(100, ErrorMessage="Nome do fornecedor excedeu o limite de tamanho maximo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [EmailAddress(ErrorMessage="E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [Phone(ErrorMessage="Numero de telefone inválido.")]
        public string Telefone { get; set; }
    }
}