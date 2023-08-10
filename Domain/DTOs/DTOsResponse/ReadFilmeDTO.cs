using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.DTOsResponse;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now; //consulta  do horario local da ambiente
}
