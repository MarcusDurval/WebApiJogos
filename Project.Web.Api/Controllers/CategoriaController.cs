using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.Application.CategoriaService;
using Project.Web.Api.Domain.CategoriaDTO;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.CategoriaRepository;

namespace Project.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IcategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(IcategoriaService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CategoriasDTO categoriaDTO)
        {
            if (categoriaDTO == null || string.IsNullOrWhiteSpace(categoriaDTO.Categoria))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }
            var categoriaMapper = _mapper.Map<Categoria_Jogos>(categoriaDTO);

            var criada = await _service.Adicionar(categoriaMapper);

            var retorno = _mapper.Map<CategoriasDTO>(categoriaMapper);

            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Categoria = await _service.ObterTotal();


            return Ok(Categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriasDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest("Dados inválidos.");

            var categoria = _mapper.Map<Categoria_Jogos>(categoriaDto);
            categoria.JogoId = id;

            var atualizada = await _service.Atualizar(categoria);

            return Ok(atualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removida = await _service.Apagar(id);

            return Ok(removida);
        }
    }
}
