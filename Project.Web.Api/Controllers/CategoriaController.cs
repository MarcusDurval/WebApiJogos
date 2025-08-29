using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.Domain.CategoriaDTO;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.CategoriaRepository;
using Project.Web.Api.Infrastructure.JogosRepository;
using Project.Web.Api.Mapper;

namespace Project.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository  ?? throw new ArgumentNullException(nameof(repository)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 

        }

        [HttpPost]
        public IActionResult Add([FromBody]CategoriasDTO categoriasdto)
        {
            if (categoriasdto == null || string.IsNullOrWhiteSpace(categoriasdto.Categoria))
            {
                return BadRequest("Nome do jogo é obrigatório.");
            }
            var categoriaMapper = _mapper.Map<Categoria_Jogos>(categoriasdto);

            _repository.Add(categoriaMapper);

            var CategoriaM = _mapper.Map<CategoriasDTO>(categoriaMapper);

            return Ok(CategoriaM);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Categoria = _repository.GetAll();

            return Ok(Categoria);
        }
    }
}
