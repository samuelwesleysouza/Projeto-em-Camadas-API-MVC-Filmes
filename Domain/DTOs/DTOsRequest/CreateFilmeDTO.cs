using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.DTOsRequest
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O título do filme é obrigatótio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Genero do filme é obrigatótio")]
        [StringLength(50, ErrorMessage = "O Tamanho do gênero não pode exceder 50")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A Duração do filme é obrigatótio")]

        [Range(70, 600, ErrorMessage = " A duração deve ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
