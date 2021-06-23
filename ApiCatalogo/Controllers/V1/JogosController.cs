using ApiCatalogo.Exceptions;
using ApiCatalogo.InputModel;
using ApiCatalogo.Services;
using ApiCatalogo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> GetAll([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var games = await _jogoService.GetAll(pagina, quantidade);
            
            if (games.Count() == 0)
            {
                return NoContent();
            }

            return Ok(games);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<JogoViewModel>> GetById([FromRoute] Guid idGame)
        {
            var game = await _jogoService.GetById(idGame);
            
            if (game == null)
            {
                return NoContent();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Create([FromBody] JogoInputModel jogoInput)
        {
            try
            {
                var game = await _jogoService.Create(jogoInput);

                return Ok(game);
            }
            catch(JogoJaCadastradoException error)            
            {
                return UnprocessableEntity("Já existe um jogo com esse nome para essa produtora");
            }
        }
        
        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid idGame, [FromBody] JogoInputModel jogoInput)
        {
            try
            {
               await _jogoService.Update(idGame, jogoInput);

               return Ok();
            }
            catch(JogoNaoCadatradoException error)
            {
                return NotFound("Não existe esse jogo");
            }
        }
        
        [HttpPatch("{idGame:guid}/preco/{price:double}")]
        public async Task<ActionResult> Patch([FromRoute] Guid idGame, [FromRoute] double price)
        {
            try
            {
                await _jogoService.UpdatePrice(idGame, price);

                return Ok();
            }
            catch(JogoNaoCadatradoException error)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid idGame)
        {
            try
            {
                await _jogoService.Remove(idGame);

                return Ok();
            }
            catch(JogoNaoCadatradoException error)
            {
                return NotFound("Não existe esse jogo");
            }
        }
    }
}
