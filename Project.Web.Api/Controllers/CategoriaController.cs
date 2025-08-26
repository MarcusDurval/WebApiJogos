using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Api.CategoriaDTO;
using Project.Web.Api.CategoriaRepository;
using Project.Web.Api.Models;

namespace Project.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _Repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _Repository = repository;
        }

        [HttpPost]
        public IActionResult Add(CategoriasDTO categorias)
        {
            var Categoria = new Categoria_Jogos(categorias.Categoria,categorias.JogoId);

            _Repository.Add(Categoria);

            return Ok(Categoria);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Categoria = _Repository.GetAll();

            return Ok(Categoria);
        }
    }
}
