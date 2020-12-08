using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ValidacaoDTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")]
        [MinLength(2, ErrorMessage="Nome inválido.")]
        [StringLength(100, ErrorMessage="Nome de categoria excedeu o limite de tamanho maximo.")]
        public string Nome { get; set; }
    }
}