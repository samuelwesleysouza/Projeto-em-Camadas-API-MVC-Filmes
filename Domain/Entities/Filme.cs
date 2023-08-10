using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get;  set; }

        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Tamanho do gênero não pode exceder 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A Duração do filme é obrigatória")]
        [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
