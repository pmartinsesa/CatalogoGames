using ApiCatalogo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {
                Guid.Parse("9C2015A9-E1F7-4141-9D84-2D621DA249C6"),
                new Jogo {
                    Id = Guid.Parse("9C2015A9-E1F7-4141-9D84-2D621DA249C6"),
                    Name = "Fifa 21",
                    Producer = "EA",
                    Price = 200
                }
            },
            {
                Guid.Parse("471AC812-0C26-4881-8BA7-E5AF517AD4D9"),
                new Jogo {
                    Id = Guid.Parse("471AC812-0C26-4881-8BA7-E5AF517AD4D9"),
                    Name = "Fifa 20",
                    Producer = "EA",
                    Price = 150
                }
            },
            {
                Guid.Parse("FF3C55D6-BFAA-4653-A71F-ECDCFE330B04"),
                new Jogo {
                    Id = Guid.Parse("FF3C55D6-BFAA-4653-A71F-ECDCFE330B04"),
                    Name = "Fifa 19",
                    Producer = "EA",
                    Price = 135
                }
            },
            {
                Guid.Parse("709EC4D8-E067-4BA7-9347-C67F0A8649CA"),
                new Jogo {
                    Id = Guid.Parse("709EC4D8-E067-4BA7-9347-C67F0A8649CA"),
                    Name = "Fifa 18",
                    Producer = "EA",
                    Price = 100
                }
            }
        };

        public void Dispose()
        {
            //Desconecta do banco de dados...
            //Nao utilizada nessa mock...
        }

        public Task<List<Jogo>> GetAll(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade)
                    .Take(quantidade)
                    .ToList()
                );
        }

        public Task<List<Jogo>> GetListByName(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Name.Equals(nome) && jogo.Producer.Equals(produtora))
                   .ToList()
                );
        }

        public Task<Jogo> GetById(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;
            }

            return Task.FromResult(jogos[id]);
        }

        public Task Create(Jogo game)
        {
            jogos.Add(game.Id, game);

            return Task.CompletedTask;
        }

        public Task Update(Jogo game)
        {
            jogos[game.Id] = game;

            return Task.CompletedTask;
        }

        public Task Remove(Guid id)
        {
            jogos.Remove(id);

            return Task.CompletedTask;
        }
    }
}
