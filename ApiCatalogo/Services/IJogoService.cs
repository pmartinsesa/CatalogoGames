using ApiCatalogo.InputModel;
using ApiCatalogo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> GetAll(int page, int quantity);
        Task<JogoViewModel> GetById(Guid id);
        Task<JogoViewModel> Create(JogoInputModel gameInput);
        Task Update(Guid id, JogoInputModel gameInput);
        Task UpdatePrice(Guid id, double price);
        Task Remove(Guid id);
    }
}
