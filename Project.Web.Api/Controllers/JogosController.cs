using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.Domain.JogoDTO;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.JogosRepository;

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
        public IActionResult Add([FromBody] JogosDto jogosDto)
        {
            if (jogosDto == null || string.IsNullOrWhiteSpace(jogosDto.Nome))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }

            var JogoMapping = _Mapper.Map<Jogos>(jogosDto);

            _Repository.Add(JogoMapping);


            var Jogos = _Mapper.Map<JogosDto>(JogoMapping);

            return Ok(Jogos);

            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jogos = _Repository.GetAll();
           
            return Ok(jogos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var jogos = _Repository.GetById(id);

            return Ok(jogos);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var DeleteJogos = _Repository.Delete(id);

            return Ok(DeleteJogos);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Jogos jogos,int id)
        {
            var UpdateJogos = _Repository.Update(jogos);

            return Ok(UpdateJogos);

        }

    }
}
