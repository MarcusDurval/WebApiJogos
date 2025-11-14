using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.Application.Service;
using Project.Web.Api.Domain.JogoDTO;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.JogosRepository;

namespace Project.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _service;
        private readonly IMapper _Mapper;

        public JogosController(IJogoService repository, IMapper mapper)
        {
            _service = repository ?? throw new ArgumentNullException(nameof(repository));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JogosDto jogosDto)
        {
            if (jogosDto == null || string.IsNullOrWhiteSpace(jogosDto.Nome))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }

            var jogo = _Mapper.Map<Jogos>(jogosDto);


            var criado =  await _service.Adicionar(jogo);


            var retorno = _Mapper.Map<JogosDto>(criado);

            return Ok(retorno);

            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int size, int page)
        {
            var jogos = await _service.ObterTotal(size,page);
           
            return Ok(jogos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jogos = await _service.ObterPorId(id);

            if (jogos == null)
            {
                return NotFound("Jogo não encontrado."); 
            }

            return Ok(jogos);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var RemoverJogos = await _service.Apagar(id);

            return Ok(RemoverJogos);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id,JogosDto dto)
        {
            var JogoAtualizado = _Mapper.Map<Jogos>(dto);
            JogoAtualizado.ID_Jogo = id;

            var atualizado = await _service.Atualizar(JogoAtualizado);

            return Ok(atualizado);

        }

    }
}
