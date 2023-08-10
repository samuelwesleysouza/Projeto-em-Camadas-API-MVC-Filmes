using Aplicattion.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.DTOsRequest;
using Domain.DTOs.DTOsResponse;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;

namespace Api.Controllers
{
    [ApiController]
    [Route("Filme")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        private readonly IMapper _mapper; 

        public FilmeController(IFilmeService filmeService, IMapper mapper) // Adicione IMapper como argumento
        {
            _filmeService = filmeService;
            _mapper = mapper; // Injete a instância de IMapper
        }

        [HttpPost("insertfilmes")]
        public async Task<IActionResult> AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO); // Use o AutoMapper para converter DTO em Filme
            var filmeId = await _filmeService.AddFilmeAsync(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filmeId }, null);
        }


      [HttpGet("getlist")]
        public async Task<IActionResult> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var filmes = await _filmeService.GetFilmesAsync(skip, take);
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            
            var filme = _filmeService.GetFilmeByIdAsync(id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            try
            {
                var filme = _mapper.Map<Filme>(filmeDTO); // Mapeie UpdateFilmeDTO para Filme
                await _filmeService.UpdateFilmeAsync(id, filme); // Passe o objeto Filme mapeado
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            try
            {
                _filmeService.DeleteFilmeAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
