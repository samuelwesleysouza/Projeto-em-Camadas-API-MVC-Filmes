using Domain.Entities;

namespace Aplicattion.Services.Interfaces;

public interface IFilmeService
{
    Task<IEnumerable<Filme>> GetFilmesAsync(int skip, int take);
    Task<Filme> GetFilmeByIdAsync(int id);
    Task<int> AddFilmeAsync(Filme filme);
    Task UpdateFilmeAsync(int id, Filme filme);
    Task DeleteFilmeAsync(int id);


}

