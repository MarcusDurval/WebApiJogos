using AutoMapper;
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
        private readonly IMapper _Mapper;

        public JogosController(IJogoRepository repository, IMapper mapper)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public IActionResult Add([FromBody] JogosDto JogosDto)
        {
            if (JogosDto == null || string.IsNullOrWhiteSpace(JogosDto.Nome))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }

            var JogoMapping = _Mapper.Map<Jogos>(JogosDto);

            _Repository.Add(JogoMapping);

            //var AddJogos = new Jogos(JogosDto.Nome);

            //_Repository.Add(AddJogos);

            var jogoDto = _Mapper.Map<JogosDto>(JogoMapping);

            return Ok(jogoDto);

            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jogos = _Repository.GetAll();
           
            return Ok(jogos);
        }
    }
}
