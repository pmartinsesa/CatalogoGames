using ApiCatalogo.Entities;
using ApiCatalogo.Exceptions;
using ApiCatalogo.InputModel;
using ApiCatalogo.Repositories;
using ApiCatalogo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> GetAll(int page, int quantity)
        {
            var games = await _jogoRepository.GetAll(page, quantity);
            
            return games.Select(game => new JogoViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            }).ToList();
        }

        public async Task<JogoViewModel> GetById(Guid id)
        {
            var game = await _jogoRepository.GetById(id);

            if (game == null)
            {
                return null;
            }

            return new JogoViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        public async Task<JogoViewModel> Create(JogoInputModel gameInput)
        {
            var gameEntity = await _jogoRepository.GetListByName(gameInput.Name, gameInput.Producer);

            if (gameEntity.Count > 0)
            {
                throw new JogoJaCadastradoException();
            }

            var gameInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Name = gameInput.Name,
                Producer = gameInput.Producer,
                Price = gameInput.Price
            };

            await _jogoRepository.Create(gameInsert);

            return new JogoViewModel
            {
                Id = gameInsert.Id,
                Name = gameInput.Name,
                Producer = gameInput.Producer,
                Price = gameInput.Price
            };
        }

        public async Task Update(Guid id, JogoInputModel gameInput)
        {
            var game = await _jogoRepository.GetById(id);

            if (game == null)
            {
                throw new JogoNaoCadatradoException();
            }

            game.Name = gameInput.Name;
            game.Producer = gameInput.Producer;
            game.Price = gameInput.Price;

            await _jogoRepository.Update(game);
        }

        public async Task UpdatePrice(Guid id, double price)
        {
            var game = await _jogoRepository.GetById(id);

            if (game == null)
            {
                throw new JogoNaoCadatradoException();
            }

            game.Price = price;

            await _jogoRepository.Update(game);
        }
        public async Task Remove(Guid id)
        {
            var game = await _jogoRepository.GetById(id);

            if (game == null)
            {
                throw new JogoNaoCadatradoException();
            }

            await _jogoRepository.Remove(id);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
