using AutoMapper;
using Domain.Entities;
using Aplicattion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace Aplicattion.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<Filme>> GetFilmesAsync(int skip, int take)
        {
            var filmes = _context.Filmes.ToList();
            return Task.FromResult<IEnumerable<Filme>>(filmes);
        }

        public Task<Filme> GetFilmeByIdAsync(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            return Task.FromResult(filme);
        }

        public async Task<int> AddFilmeAsync(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return filme.Id;
        }

        public async Task UpdateFilmeAsync(int id, Filme filme)
        {
            var existingFilme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
            if (existingFilme == null) throw new Exception("Filme não encontrado");
            if (existingFilme == null)
            {
                throw new NotFoundException("Filme não encontrado");
            }
            _mapper.Map(filme, existingFilme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilmeAsync(int id)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
            if (filme == null) throw new Exception("Filme não encontrado");

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }
    }
}
