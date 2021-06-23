using ApiCatalogo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> GetAll(int pagina, int quantidade);
        Task<List<Jogo>> GetListByName(string nome, string produtora);
        Task<Jogo> GetById(Guid id);
        Task Create(Jogo game);
        Task Update(Jogo game);
        Task Remove(Guid id);
    }
}
