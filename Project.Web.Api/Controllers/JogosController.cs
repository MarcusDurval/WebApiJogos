using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.JogoDTO;
using Project.Web.Api.Models;
using Project.Web.Api.Repositories;

namespace Project.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository _Repository;

        public JogosController(IJogoRepository repository)
        {
            _Repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] JogosDto JogosDto)
        {
            if (JogosDto == null || string.IsNullOrWhiteSpace(JogosDto.Nome))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }

            var AddJogos = new Jogos(JogosDto.Nome);

            _Repository.Add(AddJogos);

            return Ok(AddJogos);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jogos = _Repository.GetAll();
            if(jogos == null)
            {
                return BadRequest();
            }
            return Ok(jogos);
        }
    }
}
